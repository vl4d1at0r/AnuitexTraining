import {AccountState} from "../interfaces/account.state";
import {createFeatureSelector, createSelector} from "@ngrx/store";
import {
  getAccessToken,
  getFirstName,
  getLastName,
  getRefreshToken,
  getIsConfirmedEmail,
  getIsPasswordReset, getIsLoggedIn, getRememberMe
} from "./account.reducer";

export const getAccountState = createFeatureSelector<AccountState>('account');

export const getAccessTokenSelector = createSelector(
  getAccountState,
  getAccessToken
);

export const getRefreshTokenSelector = createSelector(
  getAccountState,
  getRefreshToken
);

export const getRememberMeSelector = createSelector(
  getAccountState,
  getRememberMe
);

export const getFirstNameSelector = createSelector(
  getAccountState,
  getFirstName
);

export const getLastNameSelector = createSelector(
  getAccountState,
  getLastName
);

export const getIsConfirmedEmailSelector = createSelector(
  getAccountState,
  getIsConfirmedEmail
);

export const getIsPasswordResetSelector = createSelector(
  getAccountState,
  getIsPasswordReset
)

export const getIsLoggedInSelector = createSelector(
  getAccountState,
  getIsLoggedIn
)
