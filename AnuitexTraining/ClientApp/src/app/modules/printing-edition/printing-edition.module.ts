import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {MaterialModule} from "../shared/material.module";
import {CatalogComponent} from "./components/printing-editions/catalog.component";
import {Ng5SliderModule} from "ng5-slider";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    Ng5SliderModule,
    FormsModule,
    RouterModule
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
