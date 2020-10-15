import {UserState} from "../../user/models/user.state";
import {AuthorModel} from "./author.model";
import {PrintingEditionModel} from "./printing-edition.model";

export interface AdministratorState {
  users: UserState[],
  authors: AuthorModel[],
  printingEditions: PrintingEditionModel[],
  errors: string[],
  usersTotal: number,
  authorsTotal: number,
  printingEditionsTotal: number
}
