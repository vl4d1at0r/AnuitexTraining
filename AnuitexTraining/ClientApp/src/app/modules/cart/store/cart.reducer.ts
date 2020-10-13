import {OrderModel} from "../models/order.model";
import {OrderStatusEnum} from "../../shared/enums/order-status.enum";
import {CartActions} from "./cart.actions";

export const initialCartState: OrderModel = {
  date: null,
  description: '',
  items: [],
  paymentId: 0,
  status: OrderStatusEnum.None,
  userId: 0
}

export function cartReducer(state = initialCartState, action: CartActions) {
  switch (action.type) {
    default:
      return state
  }
}
