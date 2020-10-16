import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {AuthorModel} from "../../../administrator/models/author.model";
import {OrderModel} from "../../models/order.model";

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: number) { }

  ngOnInit() {
    var stripe = Stripe("pk_test_51HMqTeKbwoGhmQ0BhRs6vDMqF8HBw5x4Tp3kvdGWZSYZxZmR1AQfApcYxDdj7ATzvA5zJxhS1NhzGRVNz1HkJ9ru00eSJCeCes");
    var elements = stripe.elements();
  }

}
