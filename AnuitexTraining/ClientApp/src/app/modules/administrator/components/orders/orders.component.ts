import {AfterViewInit, Component, EventEmitter, OnInit, ViewChild} from '@angular/core';
import {OrderModel} from "../../../cart/models/order.model";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../models/administrator.state";
import {OrderStatusEnum} from "../../../shared/enums/order-status.enum";
import {Actions, ofType} from "@ngrx/effects";
import {merge} from "rxjs";
import {BuyExistingOrderSuccess} from "../../../cart/store/cart.actions";
import {SortOrderEnum} from "../../../shared/enums/sort-order.enum";
import {PrintingEditionTypeEnum} from "../../../shared/enums/printing-edition-type.enum";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {GetOrdersAction, GetOrdersSuccess, GetOrdersSuccessAction} from "../../store/administrator.actions";

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit, AfterViewInit {
  dataSource: OrderModel[]
  displayedColumns = ["id", "date", "username", "email", "product", "title", "qty", "amount", "status"];
  length: number;
  totalPrice: number;
  statusFilter: boolean;
  paid = true;
  unPaid = true;
  refresh = new EventEmitter();
  filter: OrderModel = {
    id: 0,
    date: null,
    description: "",
    paymentId: 0,
    status: OrderStatusEnum.None,
    transactionToken: "",
    userId: 0,
    user: null,
    items: null
  };

  constructor(private administratorStore: Store<AdministratorState>,
              private actions$: Actions) { }

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  ngOnInit() {
  }

  getTotalPrice(element) {
    let price = 0;
    element.items.forEach(item => price += item.amount * item.count)
    return price;
  }

  isPaid(element: any) {
    return element.status == OrderStatusEnum.Paid
  }

  ngAfterViewInit(): void {
    this.actions$.pipe(ofType(GetOrdersSuccess)).subscribe((action: GetOrdersSuccessAction) => {
      this.dataSource = action.payload.data;
      this.length = action.payload.length;
    });

    merge(this.sort.sortChange, this.refresh, this.actions$.pipe(ofType(BuyExistingOrderSuccess))).subscribe(() => {
      this.paginator.firstPage();
      this.getOrders()
    });

    this.paginator.page.subscribe(() => {
      this.getOrders();
    });

    this.getOrders()
  }

  getOrders() {
    this.administratorStore.dispatch(new GetOrdersAction({
      page: this.paginator.pageIndex + 1,
      pageSize: this.paginator.pageSize,
      sortField: this.sort.active,
      sortOrder: SortOrderEnum[this.sort.direction],
      filter: this.filter
    }))
  }

  toType(type) {
    return PrintingEditionTypeEnum[type]
  }

  change() {
    if (this.paid == this.unPaid) {
      this.filter.status = OrderStatusEnum.None;
    }
    else if (this.paid) {
      this.filter.status = OrderStatusEnum.Paid;
    }
    else if(this.unPaid) {
      this.filter.status = OrderStatusEnum.Unpaid;
    }
    this.refresh.emit();
  }
}
