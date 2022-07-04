import { Component, OnInit } from '@angular/core';
import { forkJoin, map, Subscription } from 'rxjs';
import { Region } from '../core/models/region.model';
import { TranslationService } from '../core/services/translation.service';
import { WhereWeWorkService } from '../core/services/where-we-work.service';

@Component({
  selector: 'app-where-we-work',
  templateUrl: './where-we-work.component.html',
  styleUrls: ['./where-we-work.component.scss']
})
export class WhereWeWorkComponent implements OnInit {

  selectedItem:Region | null = null;
 
  regions: Region[] = [];
  codes :string[] = [];
  pageLoading = false;
  subscription = new Subscription();
  currentLang = "en";
  constructor(private _service: WhereWeWorkService, private _translationService: TranslationService) { }
  loadData() {
    this.pageLoading = true;
    var obs = forkJoin([
      this._service.getRegions(),

    ]).pipe(map(([regions]) => {
      return { regions }
    }));
    var sub = obs.subscribe({
      next: (res) => {
        this.pageLoading = false;
        this.regions = res.regions.data!;
        this.codes = this.regions.map(c => c.code!);
        console.log(this.codes)
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
  selectItem(code:string)
  {
    this.selectedItem = this.regions.find(c => c.code == code)!;
  }
  codeExists(id:string) : boolean{
    return this.codes.includes(id);
  }

}
