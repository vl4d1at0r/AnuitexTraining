import {Component} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'account-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent{
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
    Validators.required,
    this.checkContainsUpper
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
  });

  checkPasswordsEqual(){
    return this.passwordControl.value == this.confirmPasswordControl.value;
  }

  checkPasswordValid(){
    return this.checkContainsUpper(this.passwordControl) && this.checkContainsAlphaNumeric() && this.checkContainsLength();
  }

  checkContainsUpper(control: FormControl) {
    let password = control.value;
    let result = null;
    [...password].forEach(item => {
      if(item == item.toUpperCase()){
        result = { notHaveUpper: true };
      }
    });
    return result;
  }

  checkContainsAlphaNumeric() {
    let result = this.passwordControl.value.match(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/);
    return result != null;
  }

  checkContainsLength() {
    return this.passwordControl.value.length >= 6;
  }

  signUp() {
    if (this.checkPasswordValid()) {
    }
  }
}
