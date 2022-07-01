import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SliderRoutingModule } from './slider-routing.module';
import { SliderComponent } from './slider.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';
import { FomanticUIModule } from 'ngx-fomantic-ui';


@NgModule({
  declarations: [
    SliderComponent
  ],
  imports: [
    CommonModule,
    SliderRoutingModule,
    SharedModule,
    FormsModule,
    FomanticUIModule
  ]
})
export class SliderModule { }
