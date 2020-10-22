import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Store} from "@ngrx/store";
import {PrintingEditionModel} from "../../../administrator/models/printing-edition.model";
import {
  GetPrintingEditionAction, GetPrintingEditionSuccesAction,
  GetPrintingEditionSuccess
} from "../../store/printing-edition.actions";
import {Actions, ofType} from "@ngrx/effects";
import {printingEditionInitialState} from "../../store/printing-edition.reducer";
import {OrderModel} from "../../../cart/models/order.model";
import {AddCartItemAction} from "../../../cart/store/cart.actions";

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  id: number;
  data = printingEditionInitialState;
  qty = 1;

  constructor(private activatedRoute: ActivatedRoute,
              private store: Store<PrintingEditionModel>,
              private actions$: Actions,
              private cartStore: Store<OrderModel>) { }

  ngOnInit() {
    this.actions$.pipe(ofType(GetPrintingEditionSuccess)).subscribe((action: GetPrintingEditionSuccesAction) => {
      this.data = action.payload;
    });
    this.activatedRoute.queryParams.subscribe(params => {
      this.id = params.id;
      this.store.dispatch(new GetPrintingEditionAction(this.id))
    });
  }

  addToCart() {
    this.cartStore.dispatch(new AddCartItemAction({
      count: this.qty,
      printingEditionId: Number(this.id),
      amount: this.data.price,
      currency: this.data.currency,
      orderId: 0,
      title: this.data.title,
      id: 0
    }))
  }
}
