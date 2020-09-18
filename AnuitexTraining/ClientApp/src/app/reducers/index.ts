import {ActionReducerMap, MetaReducer} from '@ngrx/store';
import {environment} from '../../environments/environment';
import {AccountState} from '../modules/account/interfaces/account.state';
import {accountReducer} from '../modules/account/store/account.reducer';
import {UserState} from "../modules/user/models/user.state";
import {userReducer} from "../modules/user/store/user.reducer";
import {AdministratorState} from "../modules/administrator/models/administrator.state";
import {administratorReducer} from "../modules/administrator/store/administrator.reducer";

export interface State {
  account: AccountState,
  user: UserState,
  administrator: AdministratorState
}

export const reducers: ActionReducerMap<State> = {
  account: accountReducer,
  user: userReducer,
  administrator: administratorReducer
};


export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
