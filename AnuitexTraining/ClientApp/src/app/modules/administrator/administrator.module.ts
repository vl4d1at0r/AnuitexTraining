import {NgModule} from "@angular/core";
import {ClientsComponent} from "./components/clients/clients.component";
import {MaterialModule} from "../shared/material.module";
import {EffectsModule} from "@ngrx/effects";
import {AdministratorEffects} from "./store/administrator.effects";
import {AdministratorService} from "./services/administrator.service";
import {CommonModule} from "@angular/common";

@NgModule({
  declarations: [
    ClientsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    EffectsModule.forFeature([AdministratorEffects])
  ],
  exports: [
    ClientsComponent
  ],
  providers: [
    AdministratorService
  ]
})
export class AdministratorModule {

}
