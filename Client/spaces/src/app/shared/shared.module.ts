import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FooterComponent } from './components/footer/footer.component';
import { RouterModule } from '@angular/router';
import { PreloaderComponent } from './components/preloader/preloader.component';
import { SpinnerComponent } from './components/spinner/spinner.component';



@NgModule({
  declarations: [
    NavBarComponent,
    FooterComponent,
    PreloaderComponent,
    SpinnerComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    NavBarComponent,
    FooterComponent,
    PreloaderComponent,

  ]
})
export class SharedModule { }
