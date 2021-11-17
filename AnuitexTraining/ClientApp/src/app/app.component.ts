import {Component, OnInit} from '@angular/core';
import {select, Store} from "@ngrx/store";
import {AccountState} from "./modules/account/interfaces/account.state";
import {getAccessTokenSelector, getIsLoggedInSelector} from "./modules/account/store/account.selectors";
import {
  SignInSuccess,
  SignInSuccessAction,
  SignOutAction,
  SignOutSuccess
} from "./modules/account/store/account.actions";
import {NavigationStart, Router} from "@angular/router";
import {Actions, ofType} from "@ngrx/effects";
import {filter} from "rxjs/operators";
import {MatDialog} from "@angular/material/dialog";
import {ItemsComponent} from "./modules/cart/components/items/items.component";
import {AddCartItem, DeleteCartItem, EditCartItem, RestoreCartAction} from "./modules/cart/store/cart.actions";
import {OrderModel} from "./modules/cart/models/order.model";
import {getItemsSelector, getStateSelector} from "./modules/cart/store/cart.selectors";
import {checkAdmin} from "./modules/shared/common";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private accessToken: string;

  constructor(private dialog: MatDialog,
              private store: Store<AccountState>,
              private router: Router,
              private actions$: Actions,
              private cartStore: Store<OrderModel>) {
    router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        this.isOnAuthPage = event.url.includes("signIn") || event.url.includes("signUp");
      }
    })
  }

  title = 'app';
  isLoggedIn$ = this.store.select(getIsLoggedInSelector);
  invert = false;
  isAdmin = false;
  isOnAuthPage = false;

  ngOnInit() {
    let accessToken = localStorage.getItem("accessToken");
    let refreshToken = localStorage.getItem("refreshToken")
    this.actions$.pipe(ofType(SignInSuccess)).subscribe((action: SignInSuccessAction) => {
      this.isAdmin = checkAdmin(this.store);
    })
    if ((accessToken != 'null' && accessToken != null) && (refreshToken != 'null' && refreshToken != null)) {
      this.store.dispatch(new SignInSuccessAction({
        accessToken: accessToken,
        refreshToken: refreshToken,
        rememberMe: true
      }))
      let cart = localStorage.getItem("cart");
      if (cart != null && cart != 'null') {
        this.store.dispatch(new RestoreCartAction(JSON.parse(cart)))
      }
    }
    this.actions$.pipe(ofType(SignOutSuccess)).subscribe(() => {
      this.router.navigate(["account", "signIn"]).then();
    })
    this.actions$.pipe(ofType(AddCartItem, DeleteCartItem, EditCartItem)).subscribe(() => {
      this.cartStore.pipe(select(getStateSelector)).subscribe(item => {
        localStorage.setItem("cart", JSON.stringify(item))
      })
    })

  }

  signOut() {
    this.store.dispatch(new SignOutAction());
  }

  profile() {
    this.store.select(getAccessTokenSelector).subscribe(item => this.accessToken = item)
    let id = JSON.parse(atob(this.accessToken.split('.')[1])).Id;
    this.router.navigate(["user", "profile"], {
      queryParams: {
        id: id
      }
    }).then()
  }

  showCart() {
    this.dialog.open(ItemsComponent)
  }
}
