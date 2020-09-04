import { createAction, Action } from "@ngrx/store";
import { type } from "os";
import { SignInModel } from "../models/sign-in.model";
import { SignInSuccessModel } from "../models/sign-in-success.model";
import { SignInFailModel } from "../models/sign-in-fail.model";

export const SignIn = '[Sign-In Component] Sign-In';
export const SignInSuccess = '[Sign-In Component] Sign-In Success';
export const SignInFail = '[Sign-In Component] Sign-In Fail';

export class SignInAction implements Action {
    readonly type = SignIn;
    constructor(public payload: SignInModel) { }
}

export class SignInSuccessAction implements Action {
    readonly type = SignInSuccess;
    constructor(public payload: SignInSuccessModel) { }
}

export class SignInFailAction implements Action {
    readonly type = SignInFail;
    constructor(public payload: SignInFailModel) { }
}

export type AccountActions = SignInAction | SignInSuccessAction | SignInFailAction