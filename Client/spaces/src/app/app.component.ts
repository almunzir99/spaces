import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

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
  constructor(private translateService:TranslateService) {
      translateService.addLangs(["ar","en"]);

  }
}
