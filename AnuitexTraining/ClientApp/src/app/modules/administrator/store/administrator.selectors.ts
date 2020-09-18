import {createFeatureSelector, createSelector} from "@ngrx/store";
import {AdministratorState} from "../models/administrator.state";
import {getUsers} from "./administrator.reducer";

export const getAdministratorState = createFeatureSelector<AdministratorState>('administrator');

export const getUsersSelector = createSelector(
  getAdministratorState,
  getUsers
);
