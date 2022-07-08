import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MediaRoutingModule } from './media-routing.module';
import { MediaComponent } from './media.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FomanticUIModule } from 'ngx-fomantic-ui';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    MediaComponent
  ],
  imports: [
    CommonModule,
    MediaRoutingModule,
    SharedModule,
    FomanticUIModule,
    FormsModule,
  ]
})
export class MediaModule { }
