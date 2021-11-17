import {Store} from "@ngrx/store";
import {AccountState} from "../account/interfaces/account.state";
import {getAccessTokenSelector} from "../account/store/account.selectors";

export function checkAdmin(userStore: Store<AccountState>) {
  let result = false;
  userStore.select(getAccessTokenSelector).subscribe(item => {
    if (item) {
      let json = JSON.parse(atob(item.split('.')[1]));
      let role = json["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
      result = role == "Admin";
    }
  });
  return result;
}
