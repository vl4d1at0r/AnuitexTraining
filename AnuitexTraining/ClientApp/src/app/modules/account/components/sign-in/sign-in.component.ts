import {Component, OnInit} from "@angular/core";
import {FormGroup, FormControl, Validators, FormGroupDirective, NgForm} from "@angular/forms";
import {AccountState} from "../../interfaces/account.state";
import {Store} from "@ngrx/store";
import {SignInAction, SignInSuccess, SignInSuccessAction} from "../../store/account.actions";
import {ErrorStateMatcher} from "@angular/material/core";
import {Actions, ofType} from "@ngrx/effects";
import {Router} from "@angular/router";

@Component({
  selector: 'account-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private store: Store<AccountState>, private actions$: Actions, private router: Router) {
  }

  ngOnInit() {
    this.actions$.pipe(ofType(SignInSuccess)).subscribe((action: SignInSuccessAction) => {
      this.router.navigate(['']);
    });
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
    if (this.form.valid) {
      this.store.dispatch(new SignInAction({
        email: this.emailControl.value,
        password: this.passwordControl.value,
        rememberMe: this.rememberMeControl.value
      }));
    }
  }
}
