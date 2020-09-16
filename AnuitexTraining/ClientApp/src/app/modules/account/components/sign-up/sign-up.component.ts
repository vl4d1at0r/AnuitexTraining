import {Component} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AccountState} from "../../interfaces/account.state";
import {SignUpAction} from "../../store/account.actions";
import {
  checkContainsLength,
  checkContainsNumeric,
  checkContainsSpecialCharacter,
  checkContainsUpper
} from "../../../shared/validators";

@Component({
  selector: 'account-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent{

  constructor(private store:Store<AccountState>) {
  }

  userImage = require('../../assets/user.png')

  firstNameControl = new FormControl('', [
    Validators.required
  ]);
  lastNameControl = new FormControl('', [
    Validators.required
  ]);
  nickNameControl = new FormControl('',[
    Validators.required
  ]);
  emailControl = new FormControl('', [
    Validators.required,
    Validators.email
  ]);
  passwordControl = new FormControl('', [
    Validators.required,
    checkContainsUpper,
    checkContainsSpecialCharacter,
    checkContainsLength,
    checkContainsNumeric
  ]);
  confirmPasswordControl = new FormControl('',[
    Validators.required
  ]);

  form = new FormGroup({
    firstName: this.firstNameControl,
    lastName: this.lastNameControl,
    nickName: this.nickNameControl,
    email: this.emailControl,
    password: this.passwordControl,
    confirmPassword: this.confirmPasswordControl
  });

  signUp() {
    if(this.form.valid){
      this.store.dispatch(new SignUpAction({
        firstName: this.firstNameControl.value,
        lastName: this.lastNameControl.value,
        nickName: this.nickNameControl.value,
        email: this.emailControl.value,
        password: this.passwordControl.value
      }))
    }
  }
}
