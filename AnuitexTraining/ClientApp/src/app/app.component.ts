import {Component, OnInit, ViewChild} from '@angular/core';
import {MatMenu, MatMenuTrigger} from "@angular/material/menu";
import {MatMenuModule} from "@angular/material/menu";
import {Store} from "@ngrx/store";
import {AccountState} from "./modules/account/interfaces/account.state";
import {getAccessTokenSelector, getIsLoggedInSelector} from "./modules/account/store/account.selectors";
import {SignOutAction} from "./modules/account/store/account.actions";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(private store: Store<AccountState>) {
  }

  title = 'app';
  accessToken = '';
  isLoggedIn$ = this.store.select(getIsLoggedInSelector);

  ngOnInit() {
  }

  signOut() {
    this.store.dispatch(new SignOutAction());
  }
}
