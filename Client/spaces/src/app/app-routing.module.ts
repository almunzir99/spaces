import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:"",
    pathMatch:"full",
    redirectTo:"en/home",
  },
  {
    path:":lang/home",
    loadChildren: () => import("./home/home.module").then(m => m.HomeModule),
  },
  {
    path:":lang/about",
    loadChildren: () => import("./about/about.module").then(m => m.AboutModule),
  },
  {
    path:":lang/what-we-do",
    loadChildren: () => import("./what-we-do/what-we-do.module").then(m => m.WhatWeDoModule),
  },
  {
    path:":lang/where-we-work",
    loadChildren: () => import("./where-we-work/where-we-work.module").then(m => m.WhereWeWorkModule),
  },
  {
    path:":lang/get-involved",
    loadChildren: () => import("./get-involved/get-involved.module").then(m => m.GetInvolvedModule),
  },
  {
    path:":lang/donate",
    loadChildren: () => import("./donate/donate.module").then(m => m.DonateModule),
  },
  {
    path:":lang/contact-us",
    loadChildren: () => import("./contact-us/contact-us.module").then(m => m.ContactUsModule),
  },
  {
    path:":lang/volunteers",
    loadChildren: () => import("./volunteers/volunteers.module").then(m => m.VolunteersModule),
  },
  {
    path:":lang/:base/:id",
    loadChildren:() => import("./details/details.module").then(m => m.DetailsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ scrollPositionRestoration: 'enabled',})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
