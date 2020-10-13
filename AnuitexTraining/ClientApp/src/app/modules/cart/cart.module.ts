import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsComponent } from './components/items/items.component';
import {MaterialModule} from "../shared/material.module";



@NgModule({
  declarations: [ItemsComponent],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class CartModule { }
