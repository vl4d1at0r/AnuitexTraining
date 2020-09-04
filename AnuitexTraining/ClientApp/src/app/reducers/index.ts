import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import { AccountState } from '../modules/account/interfaces/account.state';
import { accountReducer } from '../modules/account/store/account.reducer';

export interface State {
  signIn: AccountState
}

export const reducers: ActionReducerMap<State> = {
  signIn: accountReducer
};


export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
