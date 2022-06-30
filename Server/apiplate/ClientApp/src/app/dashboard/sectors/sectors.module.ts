import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SectorsRoutingModule } from './sectors-routing.module';
import { SectorsComponent } from './sectors.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';
import { FomanticUIModule } from 'ngx-fomantic-ui';


@NgModule({
  declarations: [
    SectorsComponent
  ],
  imports: [
    CommonModule,
    SectorsRoutingModule,
    SharedModule,
    FormsModule,
    FomanticUIModule
  ]
})
export class SectorsModule { }
