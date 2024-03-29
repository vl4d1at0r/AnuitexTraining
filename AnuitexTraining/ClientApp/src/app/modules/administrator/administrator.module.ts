﻿import {NgModule} from "@angular/core";
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
import {PrintingEditionsComponent} from "./components/printing-editions/printing-editions.component";
import {PrintingEditionsAddDialogComponent} from "./components/printing-editions/dialogs/add/printing-editions-add-dialog.component";
import {PrintingEditionsEditDialogComponent} from "./components/printing-editions/dialogs/edit/printing-editions-edit-dialog.component";;
import { OrdersComponent } from './components/orders/orders.component'

@NgModule({
  declarations: [
    ClientsComponent,
    ClientsEditDialogComponent,
    AuthorsComponent,
    AuthorsEditDialogComponent,
    AuthorsAddDialogComponent,
    PrintingEditionsComponent,
    PrintingEditionsAddDialogComponent,
    PrintingEditionsEditDialogComponent,
    OrdersComponent
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
    AuthorsComponent,
    PrintingEditionsComponent
  ],
  providers: [
    AdministratorService
  ],
  entryComponents: [
    ClientsEditDialogComponent,
    AuthorsEditDialogComponent,
    AuthorsAddDialogComponent,
    PrintingEditionsAddDialogComponent,
    PrintingEditionsEditDialogComponent
  ]
})
export class AdministratorModule {

}
