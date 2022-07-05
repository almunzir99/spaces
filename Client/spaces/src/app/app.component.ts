import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin, map, Subscription } from 'rxjs';
import { GlobalService } from './core/services/global.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'spaces';
  /**
   *
   */
  pageLoading = false;
  subscription = new Subscription();

  constructor(private translateService: TranslateService, private _service: GlobalService) {
    translateService.addLangs(["ar", "en"]);
    this.loadData();
  }
  loadData() {
    this.pageLoading = true;
    var obs = forkJoin([
      this._service.getSectors(),

    ]).pipe(map(([sector]) => {
      return { sector }
    }));
    var sub = obs.subscribe({
      next: (res) => {
        this.pageLoading = false;
        this._service.$sectors.next(res.sector.data!);
        console.log(this._service.$sectors.value)

      },
      error: (err) => {
        this.pageLoading = false;
        console.log(err);
      }
    })
    this.subscription.add(sub);
  }
}
