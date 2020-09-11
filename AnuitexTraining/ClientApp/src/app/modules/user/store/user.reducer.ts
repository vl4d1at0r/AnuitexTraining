import {UserState} from "../models/user.state";
import {GetUserSuccess, UserActions} from "./user.actions";

export const userInitialState: UserState = {
  FirstName: '',
  LastName: '',
  Username: '',
  Email: ''
}

export function userReducer(state = userInitialState, action: UserActions) {
  switch (action.type) {
    case GetUserSuccess:
      return action.payload;
    default:
      return state;
  }
}
