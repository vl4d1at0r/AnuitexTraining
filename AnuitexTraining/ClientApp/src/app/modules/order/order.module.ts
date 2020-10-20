import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './components/list/list.component';
import {MaterialModule} from "../shared/material.module";
import {OrderService} from "./services/order.service";
import {EffectsModule} from "@ngrx/effects";
import {OrderEffects} from "./store/order.effects";



@NgModule({
  declarations: [ListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    EffectsModule.forFeature([OrderEffects])
  ],
  providers: [
    OrderService
  ]
})
export class OrderModule { }
