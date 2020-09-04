import { Component } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";
import { AccountState } from "../../interfaces/account.state";
import { Store } from "@ngrx/store";
import { SignInAction } from "../../store/account.actions";

@Component({
    selector: 'account-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {

    constructor(private store: Store<AccountState>) {}

    emailControl = new FormControl('');
    passwordControl = new FormControl('');

    form: FormGroup = new FormGroup({
        email: this.emailControl,
        password: this.passwordControl
    });

    userImage = require("../../assets/user.png");

    signIn(){
        this.store.dispatch(new SignInAction({ 
            email: this.emailControl.value, 
            password: this.passwordControl.value 
        }));


    }
}