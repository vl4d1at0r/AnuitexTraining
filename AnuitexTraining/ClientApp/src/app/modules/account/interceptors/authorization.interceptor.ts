import {Injectable} from "@angular/core";
import {HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {Store, select} from "@ngrx/store";
import {AccountState} from "../interfaces/account.state";
import {getAccessTokenSelector, getRefreshTokenSelector, getRememberMeSelector} from "../store/account.selectors";
import {CookieService} from "ngx-cookie-service";
import {catchError, switchMap} from "rxjs/operators";
import {AccountService} from "../services/account.service";
import {SignInSuccessModel} from "../models/sign-in/sign-in-success.model";
import {SignInSuccessAction, SignOutAction} from "../store/account.actions";
import {ActivatedRoute, Router} from "@angular/router";

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {

  constructor(private store: Store<AccountState>,
              private cookieService: CookieService,
              private accountService: AccountService,
              private router: Router) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let accessToken = "";
    let refreshToken = "";
    let rememberMe = false;

    this.store.pipe(select(getAccessTokenSelector)).subscribe(result => {
      accessToken = result
    })

    this.store.pipe(select(getRefreshTokenSelector)).subscribe(result => {
      refreshToken = result
    })

    this.store.pipe(select(getRememberMeSelector)).subscribe(result => {
      rememberMe = result
    })

    const authorizedRequest: HttpRequest<any> = request.clone({headers: request.headers.set('Authorization', "Bearer " + accessToken)});

    return next.handle(authorizedRequest).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status == 401 && rememberMe) {
          return this.accountService.refreshToken(accessToken, refreshToken).pipe(
            switchMap((item: SignInSuccessModel) => {
              this.store.dispatch(new SignInSuccessAction(item));
              return next.handle(request.clone({headers: request.headers.set('Authorization', "Bearer " + accessToken)}));
            })
          )
        }
        else if (error.status == 401 && !rememberMe) {
          this.store.dispatch(new SignOutAction())
          this.router.navigate(['/', 'account', 'signIn']).then();
        }
          return throwError(error);
      })
    );
  }
}
