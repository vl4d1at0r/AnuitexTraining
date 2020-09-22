import {NgModule} from "@angular/core";
import {ClientsComponent} from "./components/clients/clients.component";
import {MaterialModule} from "../shared/material.module";
import {EffectsModule} from "@ngrx/effects";
import {AdministratorEffects} from "./store/administrator.effects";
import {AdministratorService} from "./services/administrator.service";
import {CommonModule} from "@angular/common";
import {EditDialogComponent} from "./components/clients/dialogs/edit/edit-dialog.component";
import {ValidateEqualModule} from "ng-validate-equal";

@NgModule({
  declarations: [
    ClientsComponent,
    EditDialogComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    EffectsModule.forFeature([AdministratorEffects]),
    ValidateEqualModule
  ],
  exports: [
    ClientsComponent
  ],
  providers: [
    AdministratorService
  ],
  entryComponents: [
    EditDialogComponent
  ]
})
export class AdministratorModule {

}
