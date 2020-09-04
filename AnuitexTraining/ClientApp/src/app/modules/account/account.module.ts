import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { MaterialModule } from '../shared/material.module';
import { EffectsModule } from '@ngrx/effects';
import { AccountEffects } from './store/account.effects';
import { AccountService } from './services/account.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthorizationInterceptor } from './interceptors/authorization.interceptor';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    EffectsModule.forFeature([AccountEffects])
  ],
  declarations: [
    SignInComponent
  ],
  exports: [
    SignInComponent
  ],
  providers: [
    AccountService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationInterceptor,
      multi: true
    }
  ]
})
export class AccountModule { }