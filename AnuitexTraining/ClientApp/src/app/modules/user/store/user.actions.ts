import {Action} from "@ngrx/store";
import {UserState} from "../models/user.state";

export const GetUser = '[User] Get User';
export const GetUserSuccess = '[User] Get User Success';

export class GetUserAction implements Action {
  readonly type = GetUser;
  constructor(public payload: number) {
  }
}

export class GetUserSuccessAction implements Action {
  readonly type = GetUserSuccess;
  constructor(public payload: UserState) {
  }
}

export type UserActions = GetUserAction | GetUserSuccessAction;
