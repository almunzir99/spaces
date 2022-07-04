import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WhatWeDoComponent } from './what-we-do.component';
import { WhatWeDoRoutingModule } from './what-we-do-routing.module';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { HttpClientModule } from '@angular/common/http';
import { TranslateModule } from '@ngx-translate/core';



@NgModule({
  declarations: [
    WhatWeDoComponent
  ],
  imports: [
    CommonModule,
    WhatWeDoRoutingModule,
    HttpClientModule,
    TranslateModule,
    AngularSvgIconModule.forRoot()
  ]
})
export class WhatWeDoModule { }
