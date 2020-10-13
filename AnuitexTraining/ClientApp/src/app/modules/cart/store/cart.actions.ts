import {Action} from "@ngrx/store";

export const AddCartItem = "[Cart] Add Item";
export const DeleteCartItem = "[Cart] Delete Item";
export const EditCartItem = "[Cart] Edit Item";
export const BuyCart = "[Cart] Buy";
export const BuyCartSuccess = "[Cart] Buy Success";
export const BuyCartFail = "[Cart] Buy Fail";

export class AddCartItemAction implements Action {
  readonly type = AddCartItem;
}

export class DeleteCartItemAction implements Action {
  readonly type = DeleteCartItem;
}

export class EditCartItemAction implements Action {
  readonly type = EditCartItem;
}

export class BuyCartAction implements Action {
  readonly type = BuyCart;
}

export class BuyCartSuccessAction implements Action {
  readonly type = BuyCartSuccess;
}

export class BuyCartFailAction implements Action {
  readonly type = BuyCartFail;
}

export type CartActions = AddCartItemAction | DeleteCartItemAction | EditCartItemAction |
  BuyCartAction | BuyCartSuccessAction | BuyCartFailAction;
