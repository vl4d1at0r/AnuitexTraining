import {Action} from "@ngrx/store";
import {GetPageSuccessModel} from "../../administrator/models/get-page-success.model";
import {OrderModel} from "../../cart/models/order.model";
import {GetPageModel} from "../../administrator/models/get-page.model";

export const GetOrders = "[Order] Get Orders";
export const GetOrdersSuccess = "[Order] Get Orders Success";
export const GetOrdersFail = "[Order] Get Orders Fail";

export class GetOrdersAction implements Action {
  readonly type = GetOrders;
  constructor(public payload: GetPageModel<OrderModel>) {
  }
}

export class GetOrdersSuccessAction implements Action {
  readonly type = GetOrdersSuccess;
  constructor(public payload: GetPageSuccessModel<OrderModel>) {
  }
}

export class GetOrdersFailAction implements Action {
  readonly type = GetOrdersFail;
}

export type OrderActions = GetOrdersAction | GetOrdersSuccessAction | GetOrdersFailAction;
