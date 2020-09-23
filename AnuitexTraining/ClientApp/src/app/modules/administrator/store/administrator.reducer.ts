import {AdministratorState} from "../models/administrator.state";
import {AdministratorActions, AdministratorFail, DeleteUserSuccess, GetUsersSuccess} from "./administrator.actions";

export const administratorInitialState: AdministratorState = {
  users: [],
  errors: [],
  length: 0
};

export const getUsers = (state: AdministratorState) => state.users;
export const getAdministrator = (state: AdministratorState) => state;

export function administratorReducer(state = administratorInitialState, action: AdministratorActions) {
  switch (action.type) {
    case GetUsersSuccess:
      return {
        ...state,
        users: [...action.payload.users],
        length: action.payload.length
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
