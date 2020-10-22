import {Action} from "@ngrx/store";
import {OrderItemModel} from "../models/order-item.model";
import {OrderModel} from "../models/order.model";
import {BuyExistingOrderModel} from "../models/buy-existing-order.model";

export const AddCartItem = "[Cart] Add Item";
export const DeleteCartItem = "[Cart] Delete Item";
export const EditCartItem = "[Cart] Edit Item";
export const BuyCart = "[Cart] Buy";
export const BuyCartSuccess = "[Cart] Buy Success";
export const BuyCartFail = "[Cart] Buy Fail";
export const RestoreCart = "[Cart] Restore";
export const BuyExistingOrder = "[Cart] Buy Existing Order"
export const BuyExistingOrderSuccess = "[Cart] Buy Existing Order Success"
export const BuyExistingOrderFail = "[Cart] Buy Existing Order Fail"

export class AddCartItemAction implements Action {
  readonly type = AddCartItem;

  constructor(public payload: OrderItemModel) {
  }
}

export class DeleteCartItemAction implements Action {
  readonly type = DeleteCartItem;

  constructor(public payload: number) {
  }
}

export class EditCartItemAction implements Action {
  readonly type = EditCartItem;

  constructor(public payload: OrderItemModel) {
  }
}

export class BuyCartAction implements Action {
  readonly type = BuyCart;

  constructor(public payload: OrderModel) {
  }
}

export class BuyCartSuccessAction implements Action {
  readonly type = BuyCartSuccess;

  constructor(public payload: number) {
  }
}

export class BuyCartFailAction implements Action {
  readonly type = BuyCartFail;
}

export class RestoreCartAction implements Action {
  readonly type = RestoreCart;

  constructor(public payload: OrderModel) {
  }
}

export class BuyExistingOrderAction implements Action {
  readonly type = BuyExistingOrder;

  constructor(public payload: BuyExistingOrderModel) {
  }
}

export class BuyExistingOrderSuccessAction implements Action {
  readonly type = BuyExistingOrderSuccess;

  constructor(public payload: number) {
  }
}

export class BuyExistingOrderFailAction implements Action {
  readonly type = BuyExistingOrderFail;
}

export type CartActions =
  AddCartItemAction
  | DeleteCartItemAction
  | EditCartItemAction
  | BuyCartAction
  | BuyCartSuccessAction
  | BuyCartFailAction
  | RestoreCartAction
  | BuyExistingOrderAction
  | BuyExistingOrderSuccessAction
  | BuyExistingOrderFailAction;
