import {OrderItemModel} from "./order-item.model";
import {OrderStatusEnum} from "../../shared/enums/order-status.enum";
import {UserState} from "../../user/models/user.state";

export interface OrderModel {
  id: number,
  items: OrderItemModel[],
  description: string,
  userId: number,
  user: UserState,
  date: Date,
  status: OrderStatusEnum,
  paymentId: number,
  transactionToken: string
}
