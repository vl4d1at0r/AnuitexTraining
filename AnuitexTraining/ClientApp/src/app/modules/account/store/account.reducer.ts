import {AccountActions, AccountFail, ConfirmEmailSuccess, SignInSuccess} from "./account.actions";
import {AccountState} from "../interfaces/account.state";

export const signInInitialState: AccountState = {
  accessToken: "",
  refreshToken: "",
  firstName: "",
  lastName: "",
  errors: []
};

export const getAccessToken = (state: AccountState) => state.accessToken;
export const getRefreshToken = (state: AccountState) => state.refreshToken;
export const getFirstName = (state: AccountState) => state.firstName;
export const getLastName = (state: AccountState) => state.lastName;


export function accountReducer(state = signInInitialState, action: AccountActions) {
  switch (action.type) {
    case SignInSuccess: {
      return {
        ...state,
        accessToken: action.payload.accessToken,
        refreshToken: action.payload.refreshToken
      };
    }
    case AccountFail: {
      return {
        ...state,
        errors: action.payload.Errors
      }
    }
    case ConfirmEmailSuccess: {
      return {
        ...state,
        firstName: action.payload.firstName,
        lastName: action.payload.lastName
      }
    }
    default:
      return state;
  }
}
