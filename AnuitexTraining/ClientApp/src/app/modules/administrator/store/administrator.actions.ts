import {Action} from "@ngrx/store";
import {UserState} from "../../user/models/user.state";
import {FailModel} from "../../shared/models/fail.model";
import {GetUsersSuccessModel} from "../models/get-users-success.model";

export const GetUsers = '[Administrator] Get Users';
export const GetUsersSuccess = '[Administrator] Get Users Success';
export const AdministratorFail = '[Administrator] Fail';

export class GetUsersAction implements Action {
  readonly type = GetUsers;
}

export class GetUsersSuccessAction implements Action {
  readonly type = GetUsersSuccess;
  constructor(public payload: UserState[]) {
  }
}

export class AdministratorFailAction implements Action {
  readonly type = AdministratorFail;
  constructor(public payload: FailModel) {
  }
}

export type AdministratorActions = GetUsersAction | GetUsersSuccessAction | AdministratorFailAction;
