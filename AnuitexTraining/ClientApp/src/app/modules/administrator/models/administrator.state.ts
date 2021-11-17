import {UserState} from "../../user/models/user.state";
import {AuthorModel} from "./author.model";
import {PrintingEditionModel} from "./printing-edition.model";
import {OrderModel} from "../../cart/models/order.model";

export interface AdministratorState {
  users: UserState[],
  authors: AuthorModel[],
  printingEditions: PrintingEditionModel[],
  orders: OrderModel[]
  errors: string[],
  usersTotal: number,
  authorsTotal: number,
  printingEditionsTotal: number,
  ordersTotal: number
}
