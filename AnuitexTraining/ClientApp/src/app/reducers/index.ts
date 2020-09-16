import {ActionReducerMap, MetaReducer} from '@ngrx/store';
import {environment} from '../../environments/environment';
import {AccountState} from '../modules/account/interfaces/account.state';
import {accountReducer} from '../modules/account/store/account.reducer';
import {UserState} from "../modules/user/models/user.state";
import {userReducer} from "../modules/user/store/user.reducer";

export interface State {
  account: AccountState,
  user: UserState
}

export const reducers: ActionReducerMap<State> = {
  account: accountReducer,
  user: userReducer
};


export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
