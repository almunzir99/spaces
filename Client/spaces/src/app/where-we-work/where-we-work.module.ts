import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WhereWeWorkComponent } from './where-we-work.component';
import { WhereWeWorkRoutingModule } from './where-we-work-routing.module';



@NgModule({
  declarations: [
    WhereWeWorkComponent
  ],
  imports: [
    CommonModule,
    WhereWeWorkRoutingModule
  ]
})
export class WhereWeWorkModule { }
