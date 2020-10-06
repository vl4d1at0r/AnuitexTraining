import {Component, OnInit} from "@angular/core";
import {MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../../../models/administrator.state";
import {
  AddAuthorAction, AddPrintingEditionAction,
  GetAuthorsAction,
  GetAuthorsSuccess,
  GetAuthorsSuccessAction
} from "../../../../store/administrator.actions";
import {PrintingEditionTypeEnum} from "../../../../../shared/enums/printing-edition-type.enum";
import {CurrencyTypeEnum} from "../../../../../shared/enums/currency-type.enum";
import {Actions, ofType} from "@ngrx/effects";
import {SortOrderEnum} from "../../../../../shared/enums/sort-order.enum";

@Component({
  selector: 'printing-editions-add-dialog',
  templateUrl: './printing-editions-add-dialog.component.html',
  styleUrls: ['./printing-editions-add-dialog.component.css']
})
export class PrintingEditionsAddDialogComponent implements OnInit{
  constructor(public dialogRef: MatDialogRef<PrintingEditionsAddDialogComponent>,
              private store: Store<AdministratorState>,
              private actions$: Actions) {
  }

  categoryOptions = Object.keys(PrintingEditionTypeEnum).filter(item => isNaN(Number(item)) && item != "None")
  categories = PrintingEditionTypeEnum;
  currencies = CurrencyTypeEnum;
  currencyOptions = Object.keys(CurrencyTypeEnum).filter(item => isNaN(Number(item)) && item != "None")

  titleControl = new FormControl('', {
    validators: [Validators.required]
  });
  descriptionControl = new FormControl('', {
    validators: [Validators.required]
  });
  categoryControl = new FormControl(1, {
    validators: [Validators.required]
  });
  authorsControl = new FormControl([], {});
  priceControl = new FormControl('', {
    validators: [Validators.required, Validators.min(1)]
  });
  currencyControl = new FormControl(1, {
    validators: [Validators.required]
  })

  form = new FormGroup({
    title: this.titleControl,
    description: this.descriptionControl,
    category: this.categoryControl,
    authors: this.authorsControl,
    price: this.priceControl,
    currency: this.currencyControl
  })
  authors: string[];


  add() {
    if (this.form.valid) {
      this.store.dispatch(new AddPrintingEditionAction({
        title: this.titleControl.value,
        authors: this.authorsControl.value,
        currency: this.currencyControl.value,
        description: this.descriptionControl.value,
        price: this.priceControl.value,
        type: this.categoryControl.value,
        id: 0
      }));
      this.dialogRef.close();
    }
  }

  ngOnInit() {
    this.actions$.pipe(ofType(GetAuthorsSuccess)).subscribe((action: GetAuthorsSuccessAction) => {
      this.authors = action.payload.data.map(item => item.name)
    })
    this.store.dispatch(new GetAuthorsAction({
      filter: undefined,
      sortOrder: SortOrderEnum[""],
      sortField: "",
      page: 1,
      pageSize: 1000
    }));
  }
}
