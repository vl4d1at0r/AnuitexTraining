import {Component, OnInit} from "@angular/core";
import {ActivatedRoute} from "@angular/router";
import {Store} from "@ngrx/store";
import {AccountState} from "../../interfaces/account.state";
import {ConfirmEmailAction} from "../../store/account.actions";
import {getIsConfirmedEmailSelector, getFirstNameSelector, getLastNameSelector} from "../../store/account.selectors";

@Component({
  selector: 'account-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css']
})
export class ConfirmEmailComponent implements OnInit {
  id: string;
  code: string;
  confirmed: boolean;
  confirming: boolean;
  firstName = "";
  lastName = "";
  checkMarkImage = require('../../assets/check-mark.png');

  constructor(private activatedRoute: ActivatedRoute, private store: Store<AccountState>) {
  }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(params => {
      this.id = params.id;
      this.code = params.code;
    })
    if (this.id != undefined && this.code != undefined) {
      this.confirming = true;
      this.store.dispatch(new ConfirmEmailAction({id: this.id, code: this.code}));
      this.store.select(getFirstNameSelector).subscribe(item => this.firstName = item);
      this.store.select(getLastNameSelector).subscribe(item => this.lastName = item);
      this.store.select(getIsConfirmedEmailSelector).subscribe(item => this.confirmed = item)
    }
  }
}
