import {Component, OnInit} from '@angular/core';
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {OrderItemModel} from "../../models/order-item.model";
import {select, Store} from "@ngrx/store";
import {OrderModel} from "../../models/order.model";
import {getStateSelector} from "../../store/cart.selectors";
import {BuyCartAction, DeleteCartItemAction, EditCartItemAction} from "../../store/cart.actions";
import {PaymentComponent} from "../payment/payment.component";

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  order: OrderModel;
  totalPrice: number;

  constructor(public dialogRef: MatDialogRef<ItemsComponent>,
              private store: Store<OrderModel>,
              private dialog: MatDialog) {
  }

  ngOnInit() {
    this.store.pipe(select(getStateSelector)).subscribe(item => {
      this.order = item;
    })
  }

  round(item: number) {
    return Math.round(item * 100) / 100;
  }

  delete(id: number) {
    this.store.dispatch(new DeleteCartItemAction(id))
    this.store.pipe(select(getStateSelector)).subscribe(item => {
      this.order = item;
    })
  }

  edit(item: OrderItemModel) {
    this.store.dispatch(new EditCartItemAction(item))
    this.store.pipe(select(getStateSelector)).subscribe(item => {
      this.order = item;
    })
  }

  buy() {
    this.dialog.open(PaymentComponent, {data: this.totalPrice })
    this.dialogRef.close()
  }

  getTotalPrice() {
    let price = 0;
    this.order.items.forEach(item => price += item.amount * item.count)
    this.totalPrice = price
    return price;
  }
}
