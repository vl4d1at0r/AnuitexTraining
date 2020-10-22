import {OrderModel} from "../../cart/models/order.model";
import {GetPageSuccessModel} from "../../administrator/models/get-page-success.model";
import {GetOrdersSuccess, OrderActions} from "./order.actions";

export const initialOrderState: GetPageSuccessModel<OrderModel> = {
  data: [],
  length: 0
}

export function orderReducer(state = initialOrderState, action: OrderActions) {
  switch (action.type) {
    case GetOrdersSuccess:
      return action.payload;
    default:
      return state;
  }
}
