import {Component} from "@angular/core";
import {FormGroup, FormControl, Validators, FormGroupDirective, NgForm} from "@angular/forms";
import {AccountState} from "../../interfaces/account.state";
import {select, Store} from "@ngrx/store";
import {SignInAction} from "../../store/account.actions";
import {CookieService} from "ngx-cookie-service";
import {getAccessTokenSelector, getRefreshTokenSelector} from "../../store/account.selectors";
import {ErrorStateMatcher} from "@angular/material/core";

export class SignInErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'account-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {

  constructor(private store: Store<AccountState>) {
  }

  emailControl = new FormControl('', [
    Validators.required,
    Validators.email
  ]);
  passwordControl = new FormControl('', [
    Validators.required
  ]);
  rememberMeControl = new FormControl(false);

  form: FormGroup = new FormGroup({
    email: this.emailControl,
    password: this.passwordControl,
    rememberMe: this.rememberMeControl
  });

  userImage = require("../../assets/user.png");

  signIn() {
    if (this.emailControl.valid && this.passwordControl.valid) {
      this.store.dispatch(new SignInAction({
        email: this.emailControl.value,
        password: this.passwordControl.value,
        rememberMe: this.rememberMeControl.value
      }));
    }
  }

  matcher = new SignInErrorStateMatcher();
}
