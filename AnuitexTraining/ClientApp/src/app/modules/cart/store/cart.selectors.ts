import {createFeatureSelector, createSelector} from "@ngrx/store";
import {OrderModel} from "../models/order.model";
import {getItems} from "./cart.reducer";

export const getCartState = createFeatureSelector<OrderModel>('cart')

export const getItemsSelector = createSelector(
  getCartState,
  getItems
);
