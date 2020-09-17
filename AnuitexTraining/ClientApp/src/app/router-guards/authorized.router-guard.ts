import {Injectable} from "@angular/core";
import {CanActivate, Router} from "@angular/router";
import {Store} from "@ngrx/store";
import {AccountState} from "../modules/account/interfaces/account.state";
import {getIsLoggedInSelector} from "../modules/account/store/account.selectors";

@Injectable()
export class AuthorizedRouterGuard implements CanActivate {
  constructor(private store: Store<AccountState>,
              private router: Router) {
  }

  isLoggedIn: boolean;

  canActivate() {
    this.store.select(getIsLoggedInSelector).subscribe(item => this.isLoggedIn = item);
    if (this.isLoggedIn) {
      return true;
    }
    this.router.navigate(["account","signIn"]).then()
    return false;
  }
}
