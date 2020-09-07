import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {AccountService} from "../services/account.service";
import {
  SignIn,
  SignInAction,
  SignInCookieUpdateAction, SignInFail,
  SignInFailAction, SignInShowErrorsAction,
  SignInSuccess,
  SignInSuccessAction
} from "./account.actions";
import {catchError, map, mergeMap} from 'rxjs/operators';
import {SignInSuccessModel} from "../models/sign-in-success.model";
import {config, of} from "rxjs";
import {CookieService} from "ngx-cookie-service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable()
export class AccountEffects {
  constructor(private actions$: Actions,
              private signInService: AccountService,
              private cookieService: CookieService,
              private snackBar: MatSnackBar) {
  }

  @Effect()
  signIn$ = this.actions$.pipe(ofType(SignIn),
    mergeMap((action: SignInAction) => {
      return this.signInService.signIn(action.payload.email, action.payload.password)
        .pipe(
          map((data: SignInSuccessModel) => {
            data.rememberMe = action.payload.rememberMe;
            return new SignInSuccessAction(data);
          }),
          catchError(error => {
            return of(new SignInFailAction(error.error))
          })
        );
    })
  )

  @Effect()
  cookieUpdate$ = this.actions$.pipe(ofType(SignInSuccess),
    mergeMap((action: SignInSuccessAction) => {
      if (action.payload.rememberMe) {
        this.cookieService.set('accessToken', action.payload.accessToken);
        this.cookieService.set('refreshToken', action.payload.refreshToken);
      }
      return of(new SignInCookieUpdateAction());
    }))

  @Effect()
  showError$ = this.actions$.pipe(ofType(SignInFail),
    mergeMap((action: SignInFailAction) => {
      this.snackBar.open(action.payload.Errors.join("\n"), "Ok", { horizontalPosition: "end", verticalPosition: "top"})
      return of(new SignInShowErrorsAction())
    }))
}
