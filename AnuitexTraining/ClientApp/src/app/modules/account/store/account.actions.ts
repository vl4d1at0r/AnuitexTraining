import { Action } from "@ngrx/store";
import {SignUpModel} from "../models/sign-up/sign-up.model";
import {AuthenticationFailModel} from "../models/authentication-fail.model";
import {SignInModel} from "../models/sign-in/sign-in.model";
import {SignInSuccessModel} from "../models/sign-in/sign-in-success.model";

export const SignIn = '[Authentication] Sign-In';
export const SignInSuccess = '[Authentication] Sign-In Success';
export const AuthenticationFail = '[Authentication] Sign-In Fail';
export const SignInCookieUpdate = '[Authentication] Cookie Update';
export const AuthenticationShowErrors = '[Authentication] Show Errors';
export const SignUp = '[Authentication] Sign-Up';
export const SignUpSuccess = '[Authentication] Sign-Up Success';

export class SignInAction implements Action {
    readonly type = SignIn;
    constructor(public payload: SignInModel) { }
}

export class SignUpAction implements Action {
  readonly type = SignUp;
  constructor(public payload: SignUpModel) { }
}

export class SignUpSuccessAction implements Action {
  readonly type = SignUpSuccess;
}

export class SignInSuccessAction implements Action {
    readonly type = SignInSuccess;
    constructor(public payload: SignInSuccessModel) { }
}

export class AuthenticationFailAction implements Action {
    readonly type = AuthenticationFail;
    constructor(public payload: AuthenticationFailModel) { }
}

export class SignInCookieUpdateAction implements Action {
  readonly type = SignInCookieUpdate;
}

export class AuthenticationShowErrorsAction implements Action {
  readonly type = AuthenticationShowErrors;
}

export type AccountActions = SignInAction | SignInSuccessAction |
  AuthenticationFailAction | SignInCookieUpdateAction | AuthenticationShowErrorsAction |
  SignUpAction | SignUpSuccessAction;
