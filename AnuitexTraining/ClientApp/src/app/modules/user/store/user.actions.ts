import {Action} from "@ngrx/store";
import {UserState} from "../models/user.state";
import {FailModel} from "../../shared/models/fail.model";

export const GetUser = '[User] Get User';
export const GetUserSuccess = '[User] Get User Success';
export const UserFail = '[User] Fail';
export const UpdateUser = '[User] Update User';
export const UpdateUserSuccess = '[User] Update User Success';

export class GetUserAction implements Action {
  readonly type = GetUser;
  constructor(public payload: string) {
  }
}

export class GetUserSuccessAction implements Action {
  readonly type = GetUserSuccess;
  constructor(public payload: UserState) {
  }
}

export class UserFailAction implements Action {
  readonly type = UserFail;
  constructor(public payload: FailModel) {
  }
}

export class UpdateUserAction implements Action {
  readonly type = UpdateUser;
  constructor(public payload: UserState) {
  }
}

export class UpdateUserSuccessAction implements Action {
  readonly type = UpdateUserSuccess;
}

export type UserActions = GetUserAction | GetUserSuccessAction | UserFailAction |
                          UpdateUserAction | UpdateUserSuccessAction;
