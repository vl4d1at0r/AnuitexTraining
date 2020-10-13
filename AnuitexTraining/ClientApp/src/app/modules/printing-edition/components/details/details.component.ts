import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Store} from "@ngrx/store";
import {PrintingEditionModel} from "../../../administrator/models/printing-edition.model";
import {
  GetPrintingEditionAction, GetPrintingEditionSuccesAction,
  GetPrintingEditionSuccess
} from "../../store/printing-edition.actions";
import {Actions, ofType} from "@ngrx/effects";
import {printingEditionInitialState} from "../../store/printing-edition.reducer";

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  id: number;
  data = printingEditionInitialState;
  qty = 1;

  constructor(private activatedRoute: ActivatedRoute,
              private store: Store<PrintingEditionModel>,
              private actions$: Actions) { }

  ngOnInit() {
    this.actions$.pipe(ofType(GetPrintingEditionSuccess)).subscribe((action: GetPrintingEditionSuccesAction) => {
      this.data = action.payload;
    });
    this.activatedRoute.queryParams.subscribe(params => {
      this.id = params.id;
      this.store.dispatch(new GetPrintingEditionAction(this.id))
    });
  }

}
