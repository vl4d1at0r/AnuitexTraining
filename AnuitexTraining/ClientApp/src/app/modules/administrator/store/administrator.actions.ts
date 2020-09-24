import {Action} from "@ngrx/store";
import {UserState} from "../../user/models/user.state";
import {FailModel} from "../../shared/models/fail.model";
import {GetUsersModel} from "../models/get-users.model";
import {GetUsersSuccessModel} from "../models/get-users-success.model";

export const GetUsers = '[Administrator] Get Users';
export const GetUsersSuccess = '[Administrator] Get Users Success';
export const AdministratorFail = '[Administrator] Fail';
export const DeleteUser = '[Administrator] Delete User';
export const DeleteUserSuccess = '[Administrator] Delete User Success';

export class DeleteUserSuccessAction implements Action {
  readonly type = DeleteUserSuccess
}

export class GetUsersAction implements Action {
  readonly type = GetUsers;
  constructor(public payload: GetUsersModel) {
  }
}

export class GetUsersSuccessAction implements Action {
  readonly type = GetUsersSuccess;
  constructor(public payload: GetUsersSuccessModel) {
  }
}

export class AdministratorFailAction implements Action {
  readonly type = AdministratorFail;
  constructor(public payload: FailModel) {
  }
}

export class DeleteUserAction implements Action {
  readonly type = DeleteUser;
  constructor(public payload: number) {
  }
}

export type AdministratorActions = GetUsersAction  | GetUsersSuccessAction | AdministratorFailAction | DeleteUserAction | DeleteUserSuccessAction;
