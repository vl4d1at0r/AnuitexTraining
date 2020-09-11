import {Component, OnInit} from "@angular/core";
import {Store} from "@ngrx/store";
import {AccountState} from "../../account/interfaces/account.state";
import {FormControl, FormGroup} from "@angular/forms";
import {getAccessTokenSelector} from "../../account/store/account.selectors";
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'user-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  constructor(private store: Store<AccountState>) {
  }

  firstNameControl = new FormControl({value: '', disabled: true});
  lastNameControl = new FormControl({value: '', disabled: true});
  emailControl = new FormControl({value: '', disabled: true});
  passwordControl = new FormControl('');
  confirmPasswordControl = new FormControl('');

  form = new FormGroup({
    firstName: this.firstNameControl,
    lastName: this.lastNameControl,
    email: this.emailControl,
    password: this.passwordControl,
    confirmPassword: this.confirmPasswordControl
  });

  accessToken: string;
  isEditing: boolean;

  ngOnInit() {
    this.store.select(getAccessTokenSelector).subscribe(item => this.accessToken = item);
    if (this.accessToken != '') {
      let tokenInfo = JSON.parse(atob(this.accessToken.split('.')[1]));
      let id = tokenInfo.Id;
      console.log(id)
    }
  }

  applyChanges() {

  }

  edit() {
    this.isEditing = true;
    this.firstNameControl.enable();
    this.lastNameControl.enable();
    this.emailControl.enable();
  }

  cancel() {
    this.isEditing = false;
    this.firstNameControl.disable();
    this.lastNameControl.disable();
    this.emailControl.disable();
  }
}
