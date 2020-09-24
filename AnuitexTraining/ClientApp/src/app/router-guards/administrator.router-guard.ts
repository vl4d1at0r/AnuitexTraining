import {Injectable} from "@angular/core";
import {CanActivate, Router} from "@angular/router";
import {Store} from "@ngrx/store";
import {AccountState} from "../modules/account/interfaces/account.state";
import {getAccessTokenSelector, getIsLoggedInSelector} from "../modules/account/store/account.selectors";

@Injectable()
export class AdministratorRouterGuard implements CanActivate {
  constructor(private store: Store<AccountState>,
              private router: Router) {
  }

  canActivate() {
    let result = false;
    this.store.select(getAccessTokenSelector).subscribe(item => {
      if (item != "") {
        let json = JSON.parse(atob(item.split('.')[1]));
        let role = json["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
        result = role == "Admin";
      }
    });
    return result;
  }

}
