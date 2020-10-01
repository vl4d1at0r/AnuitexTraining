import {AdministratorState} from "../models/administrator.state";
import {AdministratorActions, AdministratorFail, GetAuthorsSuccess, GetUsersSuccess} from "./administrator.actions";

export const administratorInitialState: AdministratorState = {
  users: [],
  authors: [],
  errors: [],
  usersTotal: 0,
  authorsTotal: 0
};

export const getUsers = (state: AdministratorState) => state.users;
export const getAdministrator = (state: AdministratorState) => state;

export function administratorReducer(state = administratorInitialState, action: AdministratorActions) {
  switch (action.type) {
    case GetUsersSuccess:
      return {
        ...state,
        users: [...action.payload.data],
        usersTotal: action.payload.length
      }
    case GetAuthorsSuccess:
      return {
        ...state,
        authors: [...action.payload.data],
        authorsTotal: action.payload.length
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
