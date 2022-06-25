import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WhereWeWorkComponent } from './where-we-work.component';
import { WhereWeWorkRoutingModule } from './where-we-work-routing.module';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    WhereWeWorkComponent
  ],
  imports: [
    CommonModule,
    WhereWeWorkRoutingModule,
    HttpClientModule,
    AngularSvgIconModule.forRoot()
  ]
})
export class WhereWeWorkModule { }
