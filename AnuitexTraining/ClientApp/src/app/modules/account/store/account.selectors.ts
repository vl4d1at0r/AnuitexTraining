import {AccountState} from "../interfaces/account.state";
import {createFeatureSelector, createSelector} from "@ngrx/store";
import {getAccessToken, getRefreshToken} from "./account.reducer";

export const getSignInState = createFeatureSelector<AccountState>('signIn');

export const getAccessTokenSelector = createSelector(
  getSignInState,
  getAccessToken
);

export const getRefreshTokenSelector = createSelector(
  getSignInState,
  getRefreshToken
);
