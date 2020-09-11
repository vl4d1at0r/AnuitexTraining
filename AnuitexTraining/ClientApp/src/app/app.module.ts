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

const appRoutes: Routes =[
  { path: 'account/signIn', component: SignInComponent},
  { path: 'account/signUp', component: SignUpComponent},
  { path: 'account/confirmEmail', component: ConfirmEmailComponent},
  { path: 'account/forgotPassword', component: ForgotPasswordComponent},
  { path: 'user/profile', component: ProfileComponent}
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
    StoreModule.forRoot(reducers, {
      metaReducers,
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true
      }
    }),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({maxAge: 25, logOnly: environment.production}),
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
