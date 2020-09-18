import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class AdministratorService {
  constructor(private http: HttpClient) {
  }

  private userUrl = "/api/users/";
  private accountUrl = "/api/accounts/";

  getUsers() {
    return this.http.post(this.userUrl + "getAll", {
      firstName: "",
      lastName: "",
      nickname: "",
      email: "",
      password: "",
      phoneNumber: "",
      id: 0,
      creationDate: "0001-01-01T00:00:00.0000000"
    });
  }
}
