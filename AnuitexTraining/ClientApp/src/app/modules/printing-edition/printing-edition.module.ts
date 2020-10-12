import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {MaterialModule} from "../shared/material.module";
import {Ng5SliderModule} from "ng5-slider";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {CatalogComponent} from "./components/catalog/catalog.component";;
import { DetailsComponent } from './components/details/details.component'
import {PrintingEditionService} from "./services/printing-edition.service";

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    Ng5SliderModule,
    FormsModule,
    RouterModule
  ],
  declarations: [
    CatalogComponent,
    DetailsComponent
  ],
  exports: [
    CatalogComponent,
    DetailsComponent
  ],
  providers: [
    PrintingEditionService
  ]
})
export class PrintingEditionModule {

}
