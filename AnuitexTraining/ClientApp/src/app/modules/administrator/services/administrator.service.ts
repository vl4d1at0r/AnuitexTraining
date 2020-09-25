import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {UserState} from "../../user/models/user.state";
import {GetUsersModel} from "../models/get-users.model";
import {AuthorModel} from "../models/author.model";
import {GetAuthorsModel} from "../models/get-authors.model";

@Injectable()
export class AdministratorService {
  constructor(private http: HttpClient) {
  }

  private userUrl = "/api/users/";
  private accountUrl = "/api/accounts/";
  private authorUrl = "/api/authors/"

  getUsers(model: GetUsersModel) {
    return this.http.post(this.userUrl + "getAll", model);
  }

  deleteUser(id: number) {
    return this.http.delete(this.userUrl + "delete/" + id);
  }

  addAuthor(author: AuthorModel) {
    return this.http.post(this.authorUrl + "add", author)
  }

  getAuthors(model: GetAuthorsModel) {
    return this.http.post(this.authorUrl + "getPage", model)
  }
}
