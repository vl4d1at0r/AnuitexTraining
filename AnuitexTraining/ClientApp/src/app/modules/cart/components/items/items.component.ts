import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from "@angular/material/dialog";
import {Observable} from "rxjs";
import {OrderItemModel} from "../../models/order-item.model";
import {select, Store} from "@ngrx/store";
import {OrderModel} from "../../models/order.model";
import {getItemsSelector} from "../../store/cart.selectors";
import {DeleteCartItemAction, EditCartItemAction} from "../../store/cart.actions";

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  items$: Observable<OrderItemModel[]>

  constructor(public dialogRef: MatDialogRef<ItemsComponent>,
              private store: Store<OrderModel>) {
  }

  ngOnInit() {
    this.items$ = this.store.pipe(select(getItemsSelector))
  }

  round(item: number) {
    return Math.round(item * 100) / 100;
  }

  delete(id: number) {
    this.store.dispatch(new DeleteCartItemAction(id))
  }

  edit(item: OrderItemModel) {
    this.store.dispatch(new EditCartItemAction(item))
  }
}
