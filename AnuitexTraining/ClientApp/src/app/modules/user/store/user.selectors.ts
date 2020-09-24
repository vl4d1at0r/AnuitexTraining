import {createFeatureSelector, createSelector} from "@ngrx/store";
import {UserState} from "../models/user.state";
import {getUser} from "./user.reducer";

export const getUserState = createFeatureSelector<UserState>('user');

export const getUserSelector = createSelector(
  getUserState,
  getUser
);
