import {CurrencyTypeEnum} from "../../shared/enums/currency-type.enum";

export interface OrderItemModel {
  id: number
  amount: number,
  currency: CurrencyTypeEnum,
  printingEditionId: number,
  orderId: number,
  count: number,
  title: string
}
