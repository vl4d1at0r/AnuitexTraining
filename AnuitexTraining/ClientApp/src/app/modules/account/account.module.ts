import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SignInComponent} from './components/sign-in/sign-in.component';
import {MaterialModule} from '../shared/material.module';
import {EffectsModule} from '@ngrx/effects';
import {AccountEffects} from './store/account.effects';
import {AccountService} from './services/account.service';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {AuthorizationInterceptor} from './interceptors/authorization.interceptor';
import {CookieService} from "ngx-cookie-service";
import {SignUpComponent} from "./components/sign-up/sign-up.component";
import {RouterModule} from "@angular/router";

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    EffectsModule.forFeature([AccountEffects]),
    RouterModule
  ],
  declarations: [
    SignInComponent,
    SignUpComponent
  ],
  exports: [
    SignInComponent,
    SignUpComponent
  ],
  providers: [
    AccountService,
    CookieService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationInterceptor,
      multi: true
    }
  ]
})
export class AccountModule {
}
