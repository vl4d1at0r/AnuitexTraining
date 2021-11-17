import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {OrderModel} from "../../../cart/models/order.model";
import {OrderStatusEnum} from "../../../shared/enums/order-status.enum";
import {Actions, ofType} from "@ngrx/effects";
import {merge} from "rxjs";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {GetOrders, GetOrdersAction, GetOrdersSuccess, GetOrdersSuccessAction} from "../../store/order.actions";
import {GetAuthorsAction} from "../../../administrator/store/administrator.actions";
import {SortOrderEnum} from "../../../shared/enums/sort-order.enum";
import {Store} from "@ngrx/store";
import {GetPageSuccessModel} from "../../../administrator/models/get-page-success.model";
import {PrintingEditionTypeEnum} from "../../../shared/enums/printing-edition-type.enum";
import {MatDialog} from "@angular/material/dialog";
import {PaymentComponent} from "../../../cart/components/payment/payment.component";
import {BuyExistingOrderSuccess, RestoreCartAction} from "../../../cart/store/cart.actions";

@Component({
  selector: 'order-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements AfterViewInit {
  dataSource: OrderModel[]
  displayedColumns = ["id", "date", "product", "title", "qty", "amount", "status"];
  length: number
  totalPrice: number

  constructor(private actions$: Actions,
              private store: Store<GetPageSuccessModel<OrderModel>>,
              private cartStore: Store<OrderModel>,
              private dialog: MatDialog) {
  }

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;


  isPaid(element: any) {
    return element.status == OrderStatusEnum.Paid
  }

  ngAfterViewInit(): void {
    this.actions$.pipe(ofType(GetOrdersSuccess)).subscribe((action: GetOrdersSuccessAction) => {
      this.dataSource = action.payload.data;
      this.length = action.payload.length;
    });

    merge(this.sort.sortChange, this.actions$.pipe(ofType(BuyExistingOrderSuccess))).subscribe(() => {
      this.paginator.firstPage();
      this.getOrders()
    });

    this.paginator.page.subscribe(() => {
      this.getOrders();
    });

    this.getOrders()
  }

  getOrders() {
    this.store.dispatch(new GetOrdersAction({
      page: this.paginator.pageIndex + 1,
      pageSize: this.paginator.pageSize,
      sortField: this.sort.active,
      sortOrder: SortOrderEnum[this.sort.direction],
      filter: undefined
    }))
  }

  toType(type) {
    return PrintingEditionTypeEnum[type]
  }

  payOrder(element) {
    this.cartStore.dispatch(new RestoreCartAction(element))
    this.dialog.open(PaymentComponent, {data: {orderId: element.id, amount: this.getTotalPrice(element)}})
  }

  getTotalPrice(element) {
    let price = 0;
    element.items.forEach(item => price += item.amount * item.count)
    return price;
  }

  round(item: number) {
    return Math.round(item * 100) / 100;
  }
}
