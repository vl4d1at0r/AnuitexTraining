import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {UserState} from "../../user/models/user.state";

@Injectable()
export class AdministratorService {
  constructor(private http: HttpClient) {
  }

  private userUrl = "/api/users/";
  private accountUrl = "/api/accounts/";

  getUsers(filter: UserState) {
    return this.http.post(this.userUrl + "getAll", filter);
  }

  deleteUser(id: number) {
    return this.http.delete(this.userUrl + "delete/" + id);
  }
}
