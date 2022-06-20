import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { WhereWeWorkComponent } from "./where-we-work.component";
const routes : Routes = [
  {
    path:"",
    component:WhereWeWorkComponent
  }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class WhereWeWorkRoutingModule { }