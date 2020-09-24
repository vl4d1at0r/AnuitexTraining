import {UserState} from "../../user/models/user.state";

export interface AdministratorState {
  users: UserState[],
  errors: string[],
  length: number
}
