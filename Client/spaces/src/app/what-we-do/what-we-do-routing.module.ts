import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { WhatWeDoComponent } from "./what-we-do.component";
const routes : Routes = [
  {
    path:"",
    component:WhatWeDoComponent
  }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class WhatWeDoRoutingModule { }