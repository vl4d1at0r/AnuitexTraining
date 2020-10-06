import {Component, Inject, OnInit} from "@angular/core";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AuthorModel} from "../../../../models/author.model";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AdministratorState} from "../../../../models/administrator.state";
import {Store} from "@ngrx/store";
import {
  AddAuthorAction,
  EditAuthorAction,
  EditPrintingEditionAction, GetAuthorsAction,
  GetAuthorsSuccess, GetAuthorsSuccessAction
} from "../../../../store/administrator.actions";
import {PrintingEditionModel} from "../../../../models/printing-edition.model";
import {PrintingEditionTypeEnum} from "../../../../../shared/enums/printing-edition-type.enum";
import {CurrencyTypeEnum} from "../../../../../shared/enums/currency-type.enum";
import {Actions, ofType} from "@ngrx/effects";
import {SortOrderEnum} from "../../../../../shared/enums/sort-order.enum";

@Component({
  selector: 'printing-editions-edit-dialog',
  templateUrl: './printing-editions-edit-dialog.component.html',
  styleUrls: ['./printing-editions-edit-dialog.component.css']
})
export class PrintingEditionsEditDialogComponent implements OnInit{
  constructor(public dialogRef: MatDialogRef<PrintingEditionsEditDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: PrintingEditionModel,
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

  ngOnInit() {
    this.actions$.pipe(ofType(GetAuthorsSuccess)).subscribe((action: GetAuthorsSuccessAction) => {
      this.authors = action.payload.data.map(item => item.name)
      this.authorsControl.setValue(this.data.authors)
    })
    this.store.dispatch(new GetAuthorsAction({
      filter: undefined,
      sortOrder: SortOrderEnum[""],
      sortField: "",
      page: 1,
      pageSize: 1000
    }));
    this.titleControl.setValue(this.data.title)
    this.descriptionControl.setValue(this.data.description)
    this.categoryControl.setValue(this.data.type)
    this.priceControl.setValue(this.data.price)
    this.currencyControl.setValue(this.data.currency)
  }

  edit() {
    if (this.form.valid) {
      this.store.dispatch(new EditPrintingEditionAction({
        id: this.data.id,
        title: this.titleControl.value,
        type: this.categoryControl.value,
        price: this.priceControl.value,
        description: this.descriptionControl.value,
        currency: this.currencyControl.value,
        authors: this.authorsControl.value
      }));
      this.dialogRef.close();
    }
  }
}
