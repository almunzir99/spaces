import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WhereWeWorkComponent } from './where-we-work.component';
import { WhereWeWorkRoutingModule } from './where-we-work-routing.module';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
  declarations: [
    WhereWeWorkComponent
  ],
  imports: [
    CommonModule,
    WhereWeWorkRoutingModule,
    HttpClientModule,
    SharedModule,
    TranslateModule,
    AngularSvgIconModule.forRoot()
  ]
})
export class WhereWeWorkModule { }
