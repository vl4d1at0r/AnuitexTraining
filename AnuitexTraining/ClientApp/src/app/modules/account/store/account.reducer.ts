import {AccountActions, AuthenticationFail, SignInSuccess} from "./account.actions";
import {AccountState} from "../interfaces/account.state";

export const signInInitialState: AccountState = {
  accessToken: "",
  refreshToken: "",
  errors: []
};

export const getAccessToken = (state: AccountState) => state.accessToken;
export const getRefreshToken = (state: AccountState) => state.refreshToken;


export function accountReducer(state = signInInitialState, action: AccountActions) {
  switch (action.type) {
    case SignInSuccess: {
      return {
        ...state,
        accessToken: action.payload.accessToken,
        refreshToken: action.payload.refreshToken
      };
    }
    case AuthenticationFail: {
      return {
        ...state,
        errors: action.payload.Errors
      }
    }
    default:
      return state;
  }
}
