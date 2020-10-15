import {CurrencyTypeEnum} from "../../shared/enums/currency-type.enum";

export interface OrderItemModel {
  amount: number,
  currency: CurrencyTypeEnum,
  printingEditionId: number,
  orderId: number,
  count: number
}
