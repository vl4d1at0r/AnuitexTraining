import {NgModule} from "@angular/core";
import {ClientsComponent} from "./components/clients/clients.component";
import {MaterialModule} from "../shared/material.module";
import {EffectsModule} from "@ngrx/effects";
import {AdministratorEffects} from "./store/administrator.effects";
import {AdministratorService} from "./services/administrator.service";
import {CommonModule} from "@angular/common";
import {EditDialogComponent} from "./components/clients/dialogs/edit/edit-dialog.component";
import {ValidateEqualModule} from "ng-validate-equal";
import {FormsModule} from "@angular/forms";
import {AuthorsComponent} from "./components/authors/authors.component";

@NgModule({
  declarations: [
    ClientsComponent,
    EditDialogComponent,
    AuthorsComponent
  ],
    imports: [
        CommonModule,
        MaterialModule,
        EffectsModule.forFeature([AdministratorEffects]),
        ValidateEqualModule,
        FormsModule
    ],
  exports: [
    ClientsComponent,
    AuthorsComponent
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
