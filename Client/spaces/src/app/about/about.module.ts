import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutComponent } from './about.component';
import { AboutRoutingModule } from './about-routing.module';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    AboutComponent
  ],
  imports: [
    CommonModule,
    AboutRoutingModule,
    HttpClientModule,
    SharedModule,
    AngularSvgIconModule.forRoot()
  ]
})
export class AboutModule { }
