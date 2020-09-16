import {Injectable} from "@angular/core";
import {HttpInterceptor, HttpRequest, HttpHandler, HttpEvent} from "@angular/common/http";
import {Observable} from "rxjs";
import {Store, select} from "@ngrx/store";
import {AccountState} from "../interfaces/account.state";
import {getAccessTokenSelector} from "../store/account.selectors";
import {CookieService} from "ngx-cookie-service";

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {

  constructor(private store: Store<AccountState>,
              private cookieService: CookieService ) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let accessToken = "Bearer ";
    let refreshToken = "";

    this.store.pipe(select(getAccessTokenSelector)).subscribe(result => {
      accessToken += result
      if (result != "") {

      }
    })

    const authorizedRequest: HttpRequest<any> = request.clone({headers: request.headers.set('Authorization', accessToken)});

    return next.handle(authorizedRequest);
  }
}
