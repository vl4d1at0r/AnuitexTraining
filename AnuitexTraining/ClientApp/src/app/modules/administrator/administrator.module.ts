import {NgModule} from "@angular/core";
import {ClientsComponent} from "./components/clients/clients.component";
import {MaterialModule} from "../shared/material.module";

@NgModule({
  declarations: [
    ClientsComponent
  ],
  imports: [
    MaterialModule
  ],
  exports: [
    ClientsComponent
  ]
})
export class AdministratorModule {

}
