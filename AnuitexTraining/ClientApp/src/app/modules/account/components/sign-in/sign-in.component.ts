import { Component } from "@angular/core";
import { FormGroup, FormControl } from "@angular/forms";

@Component({
    selector: 'account-sign-in',
    templateUrl: './sign-in.component.html'
})
export class SignInComponent {
    form: FormGroup = new FormGroup({
        email: new FormControl(''),
        password: new FormControl('')
    });
}