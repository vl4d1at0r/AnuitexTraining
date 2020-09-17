import {
  AccountActions,
  AccountFail,
  ConfirmEmailSuccess,
  ForgotPasswordSuccess, SignIn,
  SignInSuccess,
  SignOutSuccess
} from "./account.actions";
import {AccountState} from "../interfaces/account.state";

export const accountInitialState: AccountState = {
  accessToken: "",
  refreshToken: "",
  firstName: "",
  lastName: "",
  isConfirmedEmail: false,
  isPasswordReset: false,
  isLoggedIn: false,
  rememberMe: false,
  errors: []
};

export const getAccessToken = (state: AccountState) => state.accessToken;
export const getRefreshToken = (state: AccountState) => state.refreshToken;
export const getFirstName = (state: AccountState) => state.firstName;
export const getLastName = (state: AccountState) => state.lastName;
export const getIsConfirmedEmail = (state: AccountState) => state.isConfirmedEmail;
export const getIsPasswordReset = (state: AccountState) => state.isPasswordReset;
export const getIsLoggedIn = (state: AccountState) => state.isLoggedIn;
export const getRememberMe = (state: AccountState) => state.rememberMe;


export function accountReducer(state = accountInitialState, action: AccountActions) {
  switch (action.type) {
    case SignInSuccess: {
      return {
        ...state,
        accessToken: action.payload.accessToken,
        refreshToken: action.payload.refreshToken,
        rememberMe: action.payload.rememberMe,
        isLoggedIn: true
      };
    }
    case SignIn: {
      return {
        ...state,
        rememberMe: action.payload.rememberMe
      }
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
    case SignOutSuccess: {
      return {
        ...state,
        isLoggedIn: false,
        accessToken: '',
        refreshToken: '',
        rememberMe: false
      }
    }
    default:
      return state;
  }
}
