import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { HeaderComponent } from './components/header/header.component';
import { FomanticUIModule } from 'ngx-fomantic-ui';
import { MenuComponent } from './components/menu/menu.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    DashboardComponent,
    HeaderComponent,
    MenuComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    FomanticUIModule,
    SharedModule
  ]
})
export class DashboardModule { }
