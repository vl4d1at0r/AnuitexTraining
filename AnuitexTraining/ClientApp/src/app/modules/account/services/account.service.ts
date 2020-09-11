import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SignUpModel} from "../models/sign-up/sign-up.model";
import {SignInModel} from "../models/sign-in/sign-in.model";
import {ConfirmEmailModel} from "../models/confirm-email/confirm-email.model";

@Injectable()
export class AccountService {
  private url = "/api/accounts/";

  constructor(private http: HttpClient) {
  }

  signIn(signInModel: SignInModel) {
    return this.http.get(this.url + "signIn", {
      params: {
        email: signInModel.email,
        password: signInModel.password
      }
    });
  }

  signUp(signUpModel: SignUpModel) {
    return this.http.post(this.url + "signUp", {
      firstName: signUpModel.firstName,
      lastName: signUpModel.lastName,
      userName: signUpModel.userName,
      email: signUpModel.email,
      password: signUpModel.password
    });
  }

  confirmEmail(confirmEmailModel: ConfirmEmailModel) {
    return this.http.get(this.url + "confirmEmail" + "?id=" + confirmEmailModel.id + "&code=" + encodeURIComponent(confirmEmailModel.code));
  }

  forgotPassword(email: string) {
    return this.http.get(this.url + "forgotPassword", {
      params: {
        email: email
      }
    });
  }

  signOut() {
    return this.http.get(this.url + "signOut");
  }
}
