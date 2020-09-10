import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {AccountService} from "../services/account.service";
import {
  SignIn,
  SignInAction,
  SignInCookieUpdateAction,
  AccountFail,
  AccountFailAction,
  AccountShowErrorsAction,
  SignInSuccess,
  SignInSuccessAction,
  SignUp,
  SignUpAction,
  SignUpSuccessAction,
  SignUpSuccess,
  ConfirmEmailRedirectAction,
  ConfirmEmail,
  ConfirmEmailAction,
  ConfirmEmailSuccessAction,
  ForgotPassword,
  ForgotPasswordAction,
  ForgotPasswordSuccessAction
} from "./account.actions";
import {catchError, map, mergeMap} from 'rxjs/operators';
import {config, of, pipe} from "rxjs";
import {CookieService} from "ngx-cookie-service";
import {MatSnackBar, MatSnackBarConfig} from "@angular/material/snack-bar";
import {SignInSuccessModel} from "../models/sign-in/sign-in-success.model";
import {Router} from "@angular/router";
import {ConfirmEmailSuccessModel} from "../models/confirm-email/confirm-email-success.model";

@Injectable()
export class AccountEffects {
  constructor(private actions$: Actions,
              private accountService: AccountService,
              private cookieService: CookieService,
              private snackBar: MatSnackBar,
              private router: Router) {
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
            return of(new AccountFailAction(error.error));
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
            return of(new AccountFailAction(error.error));
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
  showError$ = this.actions$.pipe(ofType(AccountFail),
    mergeMap((action: AccountFailAction) => {
      this.snackBar.open(action.payload.Errors.join(" "), "Ok", { horizontalPosition: "end", verticalPosition: "top", panelClass: 'snackbar'})
      return of(new AccountShowErrorsAction());
    }))

  @Effect()
  redirectToEmailConfirm$ = this.actions$.pipe(ofType(SignUpSuccess),
    mergeMap(() => {
      this.router.navigate(['/', 'account', 'confirmEmail']).then();
      return of(new ConfirmEmailRedirectAction());
    }))

  @Effect()
  confirmEmail$ = this.actions$.pipe(ofType(ConfirmEmail),
    mergeMap((action: ConfirmEmailAction) => {
      return this.accountService.confirmEmail(action.payload)
        .pipe(
          map((data: ConfirmEmailSuccessModel) => {
            return new ConfirmEmailSuccessAction(data);
          }),
          catchError(error => {
            return of(new AccountFailAction(error.error));
          })
        )
    }))

  @Effect()
  resetPassword$ = this.actions$.pipe(ofType(ForgotPassword),
    mergeMap((action: ForgotPasswordAction) => {
      return this.accountService.forgotPassword(action.payload)
        .pipe(
          map(() => {
            return new ForgotPasswordSuccessAction();
          }),
          catchError(error => {
            return of(new AccountFailAction(error.error));
          })
        )
    })
    )
}
