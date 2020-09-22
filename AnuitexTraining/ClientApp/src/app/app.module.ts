import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AccountModule } from './modules/account/account.module';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './reducers';
import { EffectsModule } from '@ngrx/effects';
import { AppEffects } from './app.effects';
import { SignInComponent } from './modules/account/components/sign-in/sign-in.component';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { AccountEffects } from './modules/account/store/account.effects';
import {SignUpComponent} from "./modules/account/components/sign-up/sign-up.component";
import {ConfirmEmailComponent} from "./modules/account/components/confirm-email/confirm-email.component";
import {ForgotPasswordComponent} from "./modules/account/components/forgot-password/forgot-password.component";
import {ProfileComponent} from "./modules/user/components/profile.component";
import {UserModule} from "./modules/user/user.module";
import {MaterialModule} from "./modules/shared/material.module";
import {AuthorizedRouterGuard} from "./router-guards/authorized.router-guard";
import {UnauthorizedRouterGuard} from "./router-guards/unauthorized.router-guard";
import {AdministratorModule} from "./modules/administrator/administrator.module";
import {ClientsComponent} from "./modules/administrator/components/clients/clients.component";

const appRoutes: Routes =[
  { path: 'account/signIn', component: SignInComponent, canActivate: [UnauthorizedRouterGuard]},
  { path: 'account/signUp', component: SignUpComponent, canActivate: [UnauthorizedRouterGuard]},
  { path: 'account/confirmEmail', component: ConfirmEmailComponent, canActivate: [UnauthorizedRouterGuard]},
  { path: 'account/forgotPassword', component: ForgotPasswordComponent , canActivate: [UnauthorizedRouterGuard]},
  { path: 'user/profile', component: ProfileComponent, canActivate: [AuthorizedRouterGuard]},
  { path: 'administrator/clients', component: ClientsComponent, canActivate: [AuthorizedRouterGuard]}
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    NgbModule,
    AccountModule,
    UserModule,
    AdministratorModule,
    StoreModule.forRoot(reducers, {
      metaReducers,
      runtimeChecks: {
        strictStateImmutability: false,
        strictActionImmutability: false
      }
    }),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({maxAge: 25, logOnly: environment.production}),
    MaterialModule
  ],
  providers: [AuthorizedRouterGuard, UnauthorizedRouterGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
