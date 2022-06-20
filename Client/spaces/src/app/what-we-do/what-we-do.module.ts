import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WhatWeDoComponent } from './what-we-do.component';
import { WhatWeDoRoutingModule } from './what-we-do-routing.module';



@NgModule({
  declarations: [
    WhatWeDoComponent
  ],
  imports: [
    CommonModule,
    WhatWeDoRoutingModule
  ]
})
export class WhatWeDoModule { }
