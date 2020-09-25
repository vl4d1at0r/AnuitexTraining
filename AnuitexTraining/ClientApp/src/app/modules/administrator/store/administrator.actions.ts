import {Action} from "@ngrx/store";
import {UserState} from "../../user/models/user.state";
import {FailModel} from "../../shared/models/fail.model";
import {GetUsersModel} from "../models/get-users.model";
import {GetUsersSuccessModel} from "../models/get-users-success.model";
import {GetAuthorsModel} from "../models/get-authors.model";
import {AuthorModel} from "../models/author.model";
import {GetAuthorsSuccessModel} from "../models/get-authors-success.model";

export const GetUsers = '[Administrator] Get Users';
export const GetUsersSuccess = '[Administrator] Get Users Success';
export const AdministratorFail = '[Administrator] Fail';
export const DeleteUser = '[Administrator] Delete User';
export const DeleteUserSuccess = '[Administrator] Delete User Success';
export const GetAuthors = '[Administrator] Get Authors';
export const GetAuthorsSuccess = '[Administrator] Get Authors Success';
export const AddAuthor = '[Administrator] Add Author';
export const AddAuthorSuccess = '[Administrator] Add Author Success';

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

export class GetAuthorsAction implements Action {
  readonly type = GetAuthors;
  constructor(public payload: GetAuthorsModel) {
  }
}

export class GetAuthorsSuccessAction implements Action {
  readonly type = GetAuthorsSuccess;
  constructor(public payload: GetAuthorsSuccessModel) {
  }
}

export class AddAuthorAction implements Action {
  readonly type = AddAuthor;
  constructor(public payload: AuthorModel) {
  }
}

export class AddAuthorSuccessAction implements Action {
  readonly type = AddAuthorSuccess;
}

export type AdministratorActions = GetUsersAction  | GetAuthorsSuccessAction | AdministratorFailAction | DeleteUserAction | DeleteUserSuccessAction
  | GetAuthorsAction | GetUsersSuccessAction | AddAuthorAction | AddAuthorSuccessAction;
