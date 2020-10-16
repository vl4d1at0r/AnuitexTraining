import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsComponent } from './components/items/items.component';
import {MaterialModule} from "../shared/material.module";
import {EffectsModule} from "@ngrx/effects";
import {CartEffects} from "./store/cart.effects";
import {CartService} from "./services/cart.service";
import {FormsModule} from "@angular/forms";
import { PaymentComponent } from './components/payment/payment.component';
import { SuccessComponent } from './components/success/success.component';



@NgModule({
  declarations: [ItemsComponent, PaymentComponent, SuccessComponent],
    imports: [
        CommonModule,
        MaterialModule,
        EffectsModule.forFeature([CartEffects]),
        FormsModule
    ],
  providers: [
    CartService
  ],
  entryComponents: [
    PaymentComponent,
    SuccessComponent
  ]
})
export class CartModule { }
