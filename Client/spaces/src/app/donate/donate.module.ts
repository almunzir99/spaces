import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DonateComponent } from './donate.component';
import { DonateRoutingModule } from './donate-routing.module';



@NgModule({
  declarations: [
    DonateComponent
  ],
  imports: [
    CommonModule,
    DonateRoutingModule
  ]
})
export class DonateModule { }
