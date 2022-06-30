import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SliderRoutingModule } from './slider-routing.module';
import { SliderComponent } from './slider.component';


@NgModule({
  declarations: [
    SliderComponent
  ],
  imports: [
    CommonModule,
    SliderRoutingModule
  ]
})
export class SliderModule { }
