import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, map, Subscription } from 'rxjs';
import { Project } from '../core/models/project.model';
import { Sector } from '../core/models/sector.model';
import { GlobalService } from '../core/services/global.service';
import { TranslationService } from '../core/services/translation.service';
import { WhatWeDoService } from '../core/services/what-we-do.service';

@Component({
  selector: 'app-what-we-do',
  templateUrl: './what-we-do.component.html',
  styleUrls: ['./what-we-do.component.scss']
})
export class WhatWeDoComponent implements OnInit {
  section: string | null = null;
  sector?: Sector;
  currentLang = "en";
  pageLoading = false;
  projects: Project[] = [];
  subscription = new Subscription();
  constructor(private _service: WhatWeDoService, private route: ActivatedRoute, private _globalService: GlobalService, private _translationService: TranslationService) {
    

  }

  loadData() {
    this.pageLoading = true;
    var obs = forkJoin([
      this._service.getProjects(this.sector?.id),

    ]).pipe(map(([projects]) => {
      return { projects }
    }));
    var sub = obs.subscribe({
      next: (res) => {
        this.pageLoading = false;
        this.projects = res.projects.data!;
      },
      error: (err) => {
        this.pageLoading = false;
        console.log(err);
      }
    })
    this.subscription.add(sub);
  }
  ngOnInit(): void {
    this.route.params.subscribe(res => {
      this.sector = this._globalService.$sectors.value.filter(c => c.id == res['id'])[0];
      this.loadData();
    });
    this.currentLang = this._translationService.currentLang;
    this._translationService.subscribe({
      next: (res) => {
        this.currentLang = res;
      }
    })
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
