import {Component} from "@angular/core";
import {FormControl, FormGroup, NgForm, Validators} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AccountState} from "../../interfaces/account.state";
import {ForgotPasswordAction} from "../../store/account.actions";
import {getIsPasswordResetSelector} from "../../store/account.selectors";

@Component({
  selector: 'account-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {
  constructor(private store:Store<AccountState>) {
  }

  userImage = require('../../assets/user.png');
  passwordSent: boolean;

  emailControl = new FormControl('', {
    validators: [
      Validators.required,
      Validators.email
    ]
  });

  form = new FormGroup({ email: this.emailControl });

  forgotPassword() {
    if (this.form.valid) {
      this.store.dispatch(new ForgotPasswordAction(this.emailControl.value));
      this.store.select(getIsPasswordResetSelector).subscribe(item => this.passwordSent = item);
    }
  }
}
