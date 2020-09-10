import { Action } from "@ngrx/store";
import {SignUpModel} from "../models/sign-up/sign-up.model";
import {AuthenticationFailModel} from "../models/authentication-fail.model";
import {SignInModel} from "../models/sign-in/sign-in.model";
import {SignInSuccessModel} from "../models/sign-in/sign-in-success.model";
import {ConfirmEmailModel} from "../models/confirm-email/confirm-email.model";
import {ConfirmEmailSuccessModel} from "../models/confirm-email/confirm-email-success.model";

export const SignIn = '[Account] Sign-In';
export const SignInSuccess = '[Account] Sign-In Success';
export const AccountFail = '[Account] Action Fail';
export const SignInCookieUpdate = '[Account] Cookie Update';
export const AccountShowErrors = '[Account] Show Errors';
export const SignUp = '[Account] Sign-Up';
export const SignUpSuccess = '[Account] Sign-Up Success';
export const ConfirmEmailRedirect = '[Account] Confirm Email Redirect';
export const ConfirmEmail = '[Account] Confirm Email';
export const ConfirmEmailSuccess = '[Account] Confirm Email Success';
export const ForgotPassword = '[Account] Forgot Password';
export const ForgotPasswordSuccess = '[Account] Forgot Password Success';

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

export class AccountFailAction implements Action {
    readonly type = AccountFail;
    constructor(public payload: AuthenticationFailModel) { }
}

export class SignInCookieUpdateAction implements Action {
  readonly type = SignInCookieUpdate;
}

export class AccountShowErrorsAction implements Action {
  readonly type = AccountShowErrors;
}

export class ConfirmEmailRedirectAction implements Action {
  readonly type = ConfirmEmailRedirect;
}

export class ConfirmEmailAction implements Action {
  readonly type = ConfirmEmail;
  constructor(public payload: ConfirmEmailModel) {
  }
}

export class ConfirmEmailSuccessAction implements Action {
  readonly type = ConfirmEmailSuccess;
  constructor(public payload: ConfirmEmailSuccessModel) {
  }
}

export class ForgotPasswordAction implements Action {
  readonly type = ForgotPassword;
  constructor(public payload: string) {
  }
}

export class ForgotPasswordSuccessAction implements Action {
  readonly type = ForgotPasswordSuccess;
}

export type AccountActions = SignInAction | SignInSuccessAction |
  AccountFailAction | SignInCookieUpdateAction | AccountShowErrorsAction |
  SignUpAction | SignUpSuccessAction | ConfirmEmailRedirectAction |
  ConfirmEmailAction | ConfirmEmailSuccessAction | ForgotPasswordAction |
  ForgotPasswordSuccessAction;
