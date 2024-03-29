﻿import {OrderModel} from "../models/order.model";
import {OrderStatusEnum} from "../../shared/enums/order-status.enum";
import {AddCartItem, BuyCartSuccess, CartActions, DeleteCartItem, EditCartItem, RestoreCart} from "./cart.actions";

export const initialCartState: OrderModel = {
  id: 0,
  date: null,
  description: '',
  items: [],
  paymentId: 0,
  status: OrderStatusEnum.None,
  userId: 0,
  user: null,
  transactionToken: ""
}

export const getItems = (state: OrderModel) => state.items;
export const getState = (state: OrderModel) => state;

export function cartReducer(state = initialCartState, action: CartActions) {
  switch (action.type) {
    case AddCartItem:
      let existingItem = state.items.find(item => item.printingEditionId == action.payload.printingEditionId);
      if (existingItem == null) {
        return {
          ...state,
          items: [...state.items, action.payload]
        }
      }
      return {
        ...state,
        items: state.items.filter(item => {
          if (item.printingEditionId == action.payload.printingEditionId) {
            item.count += action.payload.count
          }
          return true
        })
      }
    case DeleteCartItem:
      return {
        ...state,
        items: state.items.filter(item => item.printingEditionId != action.payload)
      }
    case EditCartItem:
      return {
        ...state,
        items: state.items.filter(item => {
          if (item.printingEditionId == action.payload.printingEditionId) {
            item.count = action.payload.count
          }
          return true;
        })
      }
    case BuyCartSuccess:
      return initialCartState;
    case RestoreCart:
      return action.payload
    default:
      return state;
  }
}
