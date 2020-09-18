import {AdministratorState} from "../models/administrator.state";
import {AdministratorActions, AdministratorFail, GetUsersSuccess} from "./administrator.actions";

export const administratorInitialState: AdministratorState = {
  users: [{firstName:"",lastName:"",nickName:"",phoneNumber:"",email:"",password:"",id:0}],
  errors: []
};

export const getUsers = (state: AdministratorState) => state.users;

export function administratorReducer(state = administratorInitialState, action: AdministratorActions) {
  switch (action.type) {
    case GetUsersSuccess:
      return {
        ...state,
        users: action.payload
      }
    case AdministratorFail:
      return {
        ...state,
        errors: action.payload.Errors
      }
    default:
      return state;
  }
}
