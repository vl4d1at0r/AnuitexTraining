import {Component} from "@angular/core";
import {MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../../../models/administrator.state";
import {AddAuthorAction} from "../../../../store/administrator.actions";
import {PrintingEditionTypeEnum} from "../../../../../shared/enums/printing-edition-type.enum";

@Component({
  selector: 'printing-editions-add-dialog',
  templateUrl: './printing-editions-add-dialog.component.html',
  styleUrls: ['./printing-editions-add-dialog.component.css']
})
export class PrintingEditionsAddDialogComponent {
  constructor(public dialogRef: MatDialogRef<PrintingEditionsAddDialogComponent>,
              private store: Store<AdministratorState>) {
    this.categories = Object.keys(PrintingEditionTypeEnum).filter(f => !isNaN(Number(f)));
  }

  categories: string[]

  titleControl = new FormControl('', {
    validators: [Validators.required]
  });
  descriptionControl = new FormControl('', {
    validators: [Validators.required]
  });
  categoryControl = new FormControl(0, {
    validators: [Validators.required]
  });
  authorsControl = new FormControl('', {
    validators: [Validators.required]
  });
  priceControl = new FormControl(0, {
    validators: [Validators.required]
  });
  currencyControl = new FormControl(0, {
    validators: [Validators.required]
  })


  add() {
    if (this.nameControl.valid) {
      this.store.dispatch(new AddAuthorAction({
        id: 0,
        name: this.nameControl.value,
        products: null
      }));
      this.dialogRef.close();
    }
  }
}
