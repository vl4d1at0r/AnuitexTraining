import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {GetPageModel} from "../../administrator/models/get-page.model";
import {OrderModel} from "../../cart/models/order.model";

@Injectable()
export class OrderService {
  url = "api/orders"

  constructor(private http: HttpClient) {
  }

  getOrders(options: GetPageModel<OrderModel>) {
    return this.http.post(this.url + "/getPage", options)
  }
}
