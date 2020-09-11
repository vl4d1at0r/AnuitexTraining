import {AccountState} from "../interfaces/account.state";
import {createFeatureSelector, createSelector} from "@ngrx/store";
import {
  getAccessToken,
  getFirstName,
  getLastName,
  getRefreshToken,
  getIsConfirmedEmail,
  getIsPasswordReset, getIsLoggedIn
} from "./account.reducer";

export const getSignInState = createFeatureSelector<AccountState>('signIn');

export const getAccessTokenSelector = createSelector(
  getSignInState,
  getAccessToken
);

export const getRefreshTokenSelector = createSelector(
  getSignInState,
  getRefreshToken
);

export const getFirstNameSelector = createSelector(
  getSignInState,
  getFirstName
);

export const getLastNameSelector = createSelector(
  getSignInState,
  getLastName
);

export const getIsConfirmedEmailSelector = createSelector(
  getSignInState,
  getIsConfirmedEmail
);

export const getIsPasswordResetSelector = createSelector(
  getSignInState,
  getIsPasswordReset
)

export const getIsLoggedInSelector = createSelector(
  getSignInState,
  getIsLoggedIn
)
