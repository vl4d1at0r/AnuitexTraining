import {Component} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AccountState} from "../../interfaces/account.state";
import {SignUpAction} from "../../store/account.actions";

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
  userNameControl = new FormControl('',[
    Validators.required
  ]);
  emailControl = new FormControl('', [
    Validators.required,
    Validators.email
  ]);
  passwordControl = new FormControl('', [
    this.checkContainsUpper,
    this.checkContainsSpecialCharacter,
    this.checkContainsLength
  ]);
  confirmPasswordControl = new FormControl('',[
    Validators.required
  ]);

  form = new FormGroup({
    firstName: this.firstNameControl,
    lastName: this.lastNameControl,
    userName: this.userNameControl,
    email: this.emailControl,
    password: this.passwordControl,
    confirmPassword: this.confirmPasswordControl
  }, {validators: [this.checkPasswordsSame]});

  checkPasswordsSame(group: FormGroup){
    if (group.get('password').value == group.get('confirmPassword').value) {
      return null;
    }
    return { notSame: true };
  }

  checkContainsUpper(control: FormControl) {
    let password = control.value;
    let result = { notHaveUpper: true };
    [...password].forEach(item => {
      if(item == item.toUpperCase() && !item.match(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/)){
        result = null;
      }
    });
    return result;
  }

  checkContainsSpecialCharacter(control: FormControl) {
    let result = control.value.match(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/);
    if (result == null) {
      return { notHaveSpecialCharacter: true };
    }
    return null;
  }

  checkContainsLength(control: FormControl) {
    if (control.value.length >= 6){
      return null;
    }
    return { notHaveLength: true };
  }

  signUp() {
    if(this.form.valid){
      this.store.dispatch(new SignUpAction({
        firstName: this.firstNameControl.value,
        lastName: this.lastNameControl.value,
        userName: this.userNameControl.value,
        email: this.emailControl.value,
        password: this.passwordControl.value
      }))
    }
  }
}
