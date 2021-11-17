import { Injectable } from '@angular/core';
import {OrderModel} from "../models/order.model";
import {HttpClient} from "@angular/common/http";
import {BuyExistingOrderModel} from "../models/buy-existing-order.model";

@Injectable()
export class CartService {
  url = "api/orders"

  constructor(private http: HttpClient) { }

  buy(payload: OrderModel) {
    return this.http.post(this.url + "/buy", payload)
  }

  buyExistingOrder(payload: BuyExistingOrderModel) {
    return this.http.get(this.url + "/buyExisting?id=" + payload.id + "&token=" + payload.token)
  }
}
