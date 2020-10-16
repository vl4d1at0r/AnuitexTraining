import { Injectable } from '@angular/core';
import {OrderModel} from "../models/order.model";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class CartService {
  url = "api/orders"

  constructor(private http: HttpClient) { }

  buy(payload: OrderModel) {
    return this.http.post(this.url, payload)
  }
}
