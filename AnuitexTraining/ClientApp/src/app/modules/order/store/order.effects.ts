import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {GetOrders, GetOrdersAction, GetOrdersFailAction, GetOrdersSuccessAction} from "./order.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {OrderService} from "../services/order.service";
import {GetPageSuccessModel} from "../../administrator/models/get-page-success.model";
import {OrderModel} from "../../cart/models/order.model";
import {of} from "rxjs";

@Injectable()
export class OrderEffects {
  constructor(private actions$: Actions,
              private orderService: OrderService) {
  }

  @Effect()
  getOrders$ = this.actions$.pipe(ofType(GetOrders),
    mergeMap((action: GetOrdersAction) => {
      return this.orderService.getOrders(action.payload)
        .pipe(
          map((data: GetPageSuccessModel<OrderModel>) => {
            return new GetOrdersSuccessAction(data);
          }),
          catchError(error => {
            return of(new GetOrdersFailAction())
          })
        )
    }))
}
