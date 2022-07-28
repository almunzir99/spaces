import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VolunteersRoutingModule } from './volunteers-routing.module';
import { VolunteersComponent } from './volunteers.component';
import { FomanticUIModule } from 'ngx-fomantic-ui';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    VolunteersComponent,
  ],
  imports: [
    CommonModule,
    VolunteersRoutingModule,
    FomanticUIModule,
    SharedModule
  ]
})
export class VolunteersModule { }
