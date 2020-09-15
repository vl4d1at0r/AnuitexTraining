import {UserState} from "../models/user.state";
import {GetUserSuccess, UpdateUser, UserActions} from "./user.actions";

export const userInitialState: UserState = {
  id: 0,
  firstName: '',
  lastName: '',
  nickName: '',
  email: '',
  password: '',
  phoneNumber: ''
}

export const getUser = (state: UserState) => state;

export function userReducer(state = userInitialState, action: UserActions) {
  switch (action.type) {
    case GetUserSuccess:
      return action.payload;
    case UpdateUser:
      return action.payload;
    default:
      return state;
  }
}
