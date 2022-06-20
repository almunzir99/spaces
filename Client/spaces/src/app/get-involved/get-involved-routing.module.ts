import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { GetInvolvedComponent } from "./get-involved.component";
const routes : Routes = [
  {
    path:"",
    component:GetInvolvedComponent
  }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class GetInvolvedRoutingModule { }