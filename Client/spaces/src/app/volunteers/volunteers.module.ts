import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VolunteersRoutingModule } from './volunteers-routing.module';
import { VolunteersComponent } from './volunteers.component';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';


@NgModule({
  declarations: [
    VolunteersComponent
  ],
  imports: [
    CommonModule,
    VolunteersRoutingModule,
    FormsModule,
    TranslateModule
  ]
})
export class VolunteersModule { }
