import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class AccountService {
    private url = "/api/accounts/";

    constructor(private http: HttpClient) {}

    signIn(email: string, password: string){
        return this.http.get(this.url + "signIn", { 
            params: {
                email: email,
                password: password
            }
        });
    }
}