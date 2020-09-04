import { createReducer, Action } from "@ngrx/store";
import { on } from "cluster";
import { AccountActions, SignInAction, SignInSuccessAction, SignIn, SignInSuccess, SignInFail } from "./account.actions";
import { AccountState } from "../interfaces/account.state";

export const signInInitialState: AccountState = {
    accessToken: "",
    refreshToken: "",
    errors: []
};

export const getAccessToken = (state: AccountState) => state.accessToken;
export const getRefreshToken = (state: AccountState) => state.refreshToken;
export const getErrors = (state: AccountState) => state.errors;


export function accountReducer(state = signInInitialState, action: AccountActions){
    switch (action.type){
        case SignInSuccess: {
            return {
                ...state,
                accessToken: action.payload.accessToken,
                refreshToken: action.payload.refreshToken
            };
        }
        case SignInFail: {
            return {
                ...state,
                errors: action.payload.Errors
            }
        }
        default:
            return state;
    }
}