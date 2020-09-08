import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {SignUpModel} from "../models/sign-up/sign-up.model";
import {SignInModel} from "../models/sign-in/sign-in.model";

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
    })
  }
}
