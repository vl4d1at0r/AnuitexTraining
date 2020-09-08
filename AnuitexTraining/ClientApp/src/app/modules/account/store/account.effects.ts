import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {AccountService} from "../services/account.service";
import {
  SignIn,
  SignInAction,
  SignInCookieUpdateAction, AuthenticationFail,
  AuthenticationFailAction, AuthenticationShowErrorsAction,
  SignInSuccess,
  SignInSuccessAction, SignUp, SignUpAction, SignUpSuccessAction
} from "./account.actions";
import {catchError, map, mergeMap} from 'rxjs/operators';
import {config, of} from "rxjs";
import {CookieService} from "ngx-cookie-service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {SignInSuccessModel} from "../models/sign-in/sign-in-success.model";

@Injectable()
export class AccountEffects {
  constructor(private actions$: Actions,
              private accountService: AccountService,
              private cookieService: CookieService,
              private snackBar: MatSnackBar) {
  }

  @Effect()
  signIn$ = this.actions$.pipe(ofType(SignIn),
    mergeMap((action: SignInAction) => {
      return this.accountService.signIn(action.payload)
        .pipe(
          map((data: SignInSuccessModel) => {
            data.rememberMe = action.payload.rememberMe;
            return new SignInSuccessAction(data);
          }),
          catchError(error => {
            return of(new AuthenticationFailAction(error.error))
          })
        );
    })
  )

  @Effect()
  signUp$ = this.actions$.pipe(ofType(SignUp),
    mergeMap((action: SignUpAction) => {
      return this.accountService.signUp(action.payload)
        .pipe(
          map(() => {
            return new SignUpSuccessAction();
          }),
          catchError(error => {
            return of(new AuthenticationFailAction(error.error))
          })
        );
    }))

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
  showError$ = this.actions$.pipe(ofType(AuthenticationFail),
    mergeMap((action: AuthenticationFailAction) => {
      this.snackBar.open(action.payload.Errors.join(" "), "Ok", { horizontalPosition: "end", verticalPosition: "top", panelClass: "snackbar"})
      return of(new AuthenticationShowErrorsAction())
    }))
}
