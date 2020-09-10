import {
  AccountActions,
  AccountFail,
  ConfirmEmailSuccess,
  ForgotPasswordSuccess,
  SignInSuccess
} from "./account.actions";
import {AccountState} from "../interfaces/account.state";

export const signInInitialState: AccountState = {
  accessToken: "",
  refreshToken: "",
  firstName: "",
  lastName: "",
  isConfirmedEmail: false,
  isPasswordReset: false,
  errors: []
};

export const getAccessToken = (state: AccountState) => state.accessToken;
export const getRefreshToken = (state: AccountState) => state.refreshToken;
export const getFirstName = (state: AccountState) => state.firstName;
export const getLastName = (state: AccountState) => state.lastName;
export const getIsConfirmedEmail = (state: AccountState) => state.isConfirmedEmail;
export const getIsPasswordReset = (state: AccountState) => state.isPasswordReset;


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
        lastName: action.payload.lastName,
        isConfirmedEmail: true
      }
    }
    case ForgotPasswordSuccess: {
      return {
        ...state,
        isPasswordReset: true
      }
    }
    default:
      return state;
  }
}
