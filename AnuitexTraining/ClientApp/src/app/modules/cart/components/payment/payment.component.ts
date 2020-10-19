import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {AuthorModel} from "../../../administrator/models/author.model";
import {OrderModel} from "../../models/order.model";
import {StripeSource, StripeToken} from "stripe-angular";

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: number) {
  }

  ngOnInit() {
  }

  setStripeToken( token:StripeToken ){
    console.log('Stripe token', token)
  }

}
