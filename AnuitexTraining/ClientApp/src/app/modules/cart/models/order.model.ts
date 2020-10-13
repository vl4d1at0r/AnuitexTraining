import {OrderItemModel} from "./order-item.model";
import {OrderStatusEnum} from "../../shared/enums/order-status.enum";

export interface OrderModel {
  items: OrderItemModel[],
  description: string,
  userId: number,
  date: Date,
  status: OrderStatusEnum,
  paymentId: number
}
