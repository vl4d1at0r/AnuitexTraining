﻿import {AdministratorState} from "../models/administrator.state";
import {AdministratorActions, AdministratorFail, DeleteUserSuccess, GetUsersSuccess} from "./administrator.actions";

export const administratorInitialState: AdministratorState = {
  users: [],
  errors: []
};

export const getUsers = (state: AdministratorState) => state.users;

export function administratorReducer(state = administratorInitialState, action: AdministratorActions) {
  switch (action.type) {
    case GetUsersSuccess:
      return {
        ...state,
        users: [...action.payload]
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