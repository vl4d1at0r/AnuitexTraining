import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {MaterialModule} from "../shared/material.module";
import {CatalogComponent} from "./components/printing-editions/catalog.component";

@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [
    CatalogComponent
  ],
  exports: [
    CatalogComponent
  ]
})
export class PrintingEditionModule {

}
