import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {UserState} from "../../user/models/user.state";
import {AuthorModel} from "../models/author.model";
import {GetPageModel} from "../models/get-page.model";
import {PrintingEditionModel} from "../models/printing-edition.model";
import {PrintingEditionFilterModel} from "../models/printing-edition-filter.model";
import {OrderModel} from "../../cart/models/order.model";

@Injectable()
export class AdministratorService {
  constructor(private http: HttpClient) {
  }

  private userUrl = "/api/users/";
  private accountUrl = "/api/accounts/";
  private authorUrl = "/api/authors/";
  private printingEditionUrl = "/api/printingEditions/";
  private orderUrl = "/api/orders/";

  getUsers(model: GetPageModel<UserState>) {
    return this.http.post(this.userUrl + "getPage", model);
  }

  deleteUser(id: number) {
    return this.http.delete(this.userUrl + "delete/" + id);
  }

  addAuthor(author: AuthorModel) {
    return this.http.post(this.authorUrl + "add", author)
  }

  getAuthors(model: GetPageModel<AuthorModel>) {
    return this.http.post(this.authorUrl + "getPage", model)
  }

  editAuthor(author: AuthorModel) {
    return this.http.put(this.authorUrl + "update", author)
  }

  deleteAuthor(id: number) {
    return this.http.delete(this.authorUrl + "delete/" + id);
  }

  getPrintingEditions(model: GetPageModel<PrintingEditionFilterModel>) {
    return this.http.post(this.printingEditionUrl + "getPage", model);
  }

  addPrintingEdition(model: PrintingEditionModel) {
    return this.http.post(this.printingEditionUrl + "add", model)
  }

  deletePrintingEdition(id: number) {
    return this.http.delete(this.printingEditionUrl + "delete/" + id)
  }

  editPrintingEdition(model: PrintingEditionModel) {
    return this.http.put(this.printingEditionUrl + "update", model)
  }

  getOrders(payload: GetPageModel<OrderModel>) {
    return this.http.post(this.orderUrl + "getPage", payload)
  }
}
