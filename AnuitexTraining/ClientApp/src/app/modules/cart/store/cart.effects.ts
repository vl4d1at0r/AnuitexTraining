import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {CartService} from "../services/cart.service";
import {
  BuyCart,
  BuyCartAction,
  BuyCartFailAction,
  BuyCartSuccessAction,
  BuyExistingOrder,
  BuyExistingOrderAction, BuyExistingOrderFailAction, BuyExistingOrderSuccessAction
} from "./cart.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {of} from "rxjs";

@Injectable()
export class CartEffects {
  constructor(private actions$: Actions,
              private cartService: CartService) {
  }

  @Effect()
  buyCart$ = this.actions$.pipe(ofType(BuyCart),
    mergeMap((action: BuyCartAction) => {
      return this.cartService.buy(action.payload)
        .pipe(
          map((item: number) => {
            return new BuyCartSuccessAction(item);
          }),
          catchError(error => {
            return of(new BuyCartFailAction())
          })
        )
    }))

  @Effect()
  buyExistingOrder$ = this.actions$.pipe(ofType(BuyExistingOrder),
    mergeMap((action: BuyExistingOrderAction) => {
      return this.cartService.buyExistingOrder(action.payload)
        .pipe(
          map((item: number) => {
            return new BuyExistingOrderSuccessAction(item)
          }),
          catchError(error => {
            return of(new BuyExistingOrderFailAction())
          })
        )
    }))
}
