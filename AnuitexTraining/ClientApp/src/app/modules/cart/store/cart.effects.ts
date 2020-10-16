import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {CartService} from "../services/cart.service";
import {BuyCart, BuyCartAction, BuyCartFailAction, BuyCartSuccessAction} from "./cart.actions";
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
          map(item => {
            return new BuyCartSuccessAction();
          }),
          catchError(error => {
            return of(new BuyCartFailAction())
          })
        )
    }))
}
