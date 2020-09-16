import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {UserState} from "../models/user.state";

@Injectable()
export class UserService {
  private url = "/api/users/";

  constructor(private http: HttpClient) {
  }

  getUser(id: string) {
    return this.http.get(this.url + "get/" + id);
  }

  updateUser(user: UserState) {
    return this.http.put(this.url + "update", user);
  }
}
