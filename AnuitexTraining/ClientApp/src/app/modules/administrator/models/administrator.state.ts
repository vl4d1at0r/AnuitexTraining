import {UserState} from "../../user/models/user.state";
import {AuthorModel} from "./author.model";

export interface AdministratorState {
  users: UserState[],
  authors: AuthorModel[],
  errors: string[],
  usersTotal: number,
  authorsTotal: number
}
