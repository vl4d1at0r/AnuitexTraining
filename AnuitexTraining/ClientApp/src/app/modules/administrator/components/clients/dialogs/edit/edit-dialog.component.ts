import {AfterViewInit, Component, Inject, OnInit} from "@angular/core";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {UserState} from "../../../../../user/models/user.state";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {
  checkContainsLength,
  checkContainsNumeric,
  checkContainsSpecialCharacter,
  checkContainsUpper
} from "../../../../../shared/validators";
import {Store} from "@ngrx/store";
import {UpdateUserAction} from "../../../../../user/store/user.actions";

@Component({
  selector: 'edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.css']
})
export class EditDialogComponent implements OnInit{
  constructor(public dialogRef: MatDialogRef<EditDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: UserState,
              private store: Store<UserState>) {
  }

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
    checkContainsUpper,
    checkContainsSpecialCharacter,
    checkContainsLength,
    checkContainsNumeric
  ]);
  confirmPasswordControl = new FormControl('',[]);

  form = new FormGroup({
    firstName: this.firstNameControl,
    lastName: this.lastNameControl,
    nickName: this.nickNameControl,
    email: this.emailControl,
    password: this.passwordControl,
    confirmPassword: this.confirmPasswordControl
  });

  save() {
    if(this.form.valid) {
      let result: UserState = {
        email: this.emailControl.value,
        nickName: this.nickNameControl.value,
        firstName: this.firstNameControl.value,
        lastName: this.lastNameControl.value,
        id: this.data.id,
        isBlocked: this.data.isBlocked,
        password: this.data.password,
        phoneNumber: this.data.phoneNumber,
        creationDate: this.data.creationDate
      }
      this.store.dispatch(new UpdateUserAction(result));
      this.dialogRef.close(result);
    }
  }

  ngOnInit(): void {
    this.firstNameControl.setValue(this.data.firstName);
    this.lastNameControl.setValue(this.data.lastName);
    this.nickNameControl.setValue(this.data.nickName);
    this.emailControl.setValue(this.data.email);
  }
}
