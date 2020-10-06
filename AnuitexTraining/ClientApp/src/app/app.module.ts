import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule, Routes} from '@angular/router';

import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {AccountModule} from './modules/account/account.module';
import {StoreModule} from '@ngrx/store';
import {metaReducers, reducers} from './reducers';
import {EffectsModule} from '@ngrx/effects';
import {SignInComponent} from './modules/account/components/sign-in/sign-in.component';
import {StoreDevtoolsModule} from '@ngrx/store-devtools';
import {environment} from '../environments/environment';
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
import {AuthorsComponent} from "./modules/administrator/components/authors/authors.component";
import {AdministratorRouterGuard} from "./router-guards/administrator.router-guard";
import {PrintingEditionsComponent} from "./modules/administrator/components/printing-editions/printing-editions.component";
import {CatalogComponent} from "./modules/printing-edition/components/printing-editions/catalog.component";
import {PrintingEditionModule} from "./modules/printing-edition/printing-edition.module";

const appRoutes: Routes = [
  {path: 'account/signIn', component: SignInComponent, canActivate: [UnauthorizedRouterGuard]},
  {path: 'account/signUp', component: SignUpComponent, canActivate: [UnauthorizedRouterGuard]},
  {path: 'account/confirmEmail', component: ConfirmEmailComponent, canActivate: [UnauthorizedRouterGuard]},
  {path: 'account/forgotPassword', component: ForgotPasswordComponent, canActivate: [UnauthorizedRouterGuard]},
  {path: 'user/profile', component: ProfileComponent, canActivate: [AuthorizedRouterGuard]},
  {
    path: 'administrator/clients',
    component: ClientsComponent,
    canActivate: [AuthorizedRouterGuard, AdministratorRouterGuard]
  },
  {
    path: 'administrator/authors',
    component: AuthorsComponent,
    canActivate: [AuthorizedRouterGuard, AdministratorRouterGuard]
  },
  {
    path: 'administrator/printingEditions',
    component: PrintingEditionsComponent,
    canActivate: [AuthorizedRouterGuard, AdministratorRouterGuard]
  },
  {path: 'printingEdition/catalog', component: CatalogComponent}
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
    PrintingEditionModule,
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
  providers: [AuthorizedRouterGuard, UnauthorizedRouterGuard, AdministratorRouterGuard],
  bootstrap: [AppComponent]
})
export class AppModule {
}
