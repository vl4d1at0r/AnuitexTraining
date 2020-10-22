import {ActionReducerMap, MetaReducer} from '@ngrx/store';
import {environment} from '../../environments/environment';
import {AccountState} from '../modules/account/interfaces/account.state';
import {accountReducer} from '../modules/account/store/account.reducer';
import {UserState} from "../modules/user/models/user.state";
import {userReducer} from "../modules/user/store/user.reducer";
import {AdministratorState} from "../modules/administrator/models/administrator.state";
import {administratorReducer} from "../modules/administrator/store/administrator.reducer";
import {PrintingEditionModel} from "../modules/administrator/models/printing-edition.model";
import {printingEditionReducer} from "../modules/printing-edition/store/printing-edition.reducer";
import {OrderModel} from "../modules/cart/models/order.model";
import {cartReducer} from "../modules/cart/store/cart.reducer";
import {GetPageSuccessModel} from "../modules/administrator/models/get-page-success.model";
import {orderReducer} from "../modules/order/store/order.reducer";

export interface State {
  account: AccountState,
  user: UserState,
  administrator: AdministratorState,
  printingEdition: PrintingEditionModel,
  cart: OrderModel,
  order: GetPageSuccessModel<OrderModel>
}

export const reducers: ActionReducerMap<State> = {
  account: accountReducer,
  user: userReducer,
  administrator: administratorReducer,
  printingEdition: printingEditionReducer,
  cart: cartReducer,
  order: orderReducer
};


export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
