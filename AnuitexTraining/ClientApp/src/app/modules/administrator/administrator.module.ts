import {NgModule} from "@angular/core";
import {ClientsComponent} from "./components/clients/clients.component";
import {MaterialModule} from "../shared/material.module";
import {EffectsModule} from "@ngrx/effects";
import {AdministratorEffects} from "./store/administrator.effects";
import {AdministratorService} from "./services/administrator.service";
import {CommonModule} from "@angular/common";
import {ClientsEditDialogComponent} from "./components/clients/dialogs/edit/clients-edit-dialog.component";
import {ValidateEqualModule} from "ng-validate-equal";
import {FormsModule} from "@angular/forms";
import {AuthorsComponent} from "./components/authors/authors.component";
import {AuthorsEditDialogComponent} from "./components/authors/dialogs/edit/authors-edit-dialog.component";
import {AuthorsAddDialogComponent} from "./components/authors/dialogs/add/authors-add-dialog.component";

@NgModule({
  declarations: [
    ClientsComponent,
    ClientsEditDialogComponent,
    AuthorsComponent,
    AuthorsEditDialogComponent,
    AuthorsAddDialogComponent
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
    ClientsEditDialogComponent,
    AuthorsEditDialogComponent,
    AuthorsAddDialogComponent
  ]
})
export class AdministratorModule {

}
