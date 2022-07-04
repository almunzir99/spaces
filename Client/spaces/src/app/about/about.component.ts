import { Component, OnInit } from '@angular/core';
import { forkJoin, map, Subscription } from 'rxjs';
import { Team } from '../core/models/team.model';
import { AboutService } from '../core/services/about.service';
import { TranslationService } from '../core/services/translation.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  values = [
    {
      "title": "Humanity",
    },
    {
      "title": "transparenacy",
    },
    {
      "title": "Accountability",
    },
    {
      "title": "Impartiality",
    },
    {
      "title": "Neutrality",
    },
    {
      "title": "Independence",
    },

  ];
  
  team: Team[] = [];
  pageLoading = false;
  subscription = new Subscription();
  currentLang = "en";
  constructor(private _service: AboutService, private _translationService: TranslationService) { }
  loadData() {
    this.pageLoading = true;
    var obs = forkJoin([
      this._service.getTeam(),

    ]).pipe(map(([team]) => {
      return { team }
    }));
    var sub = obs.subscribe({
      next: (res) => {
        this.pageLoading = false;
        this.team = res.team.data!;

      },
      error: (err) => {
        this.pageLoading = false;
        console.log(err);
      }
    })
    this.subscription.add(sub);
  }
  ngOnInit(): void {
    this.currentLang = this._translationService.currentLang;
    this.loadData();
    this._translationService.subscribe({next: (res) =>{
      this.currentLang = res;
  }})
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
