import {Component, Inject, OnInit} from "@angular/core";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AuthorModel} from "../../../../models/author.model";
import {FormControl, Validators} from "@angular/forms";
import {AdministratorState} from "../../../../models/administrator.state";
import {Store} from "@ngrx/store";
import {AddAuthorAction, EditAuthorAction} from "../../../../store/administrator.actions";
import {PrintingEditionModel} from "../../../../models/printing-edition.model";

@Component({
  selector: 'printing-editions-edit-dialog',
  templateUrl: './printing-editions-edit-dialog.component.html',
  styleUrls: ['./printing-editions-edit-dialog.component.css']
})
export class PrintingEditionsEditDialogComponent implements OnInit{
  constructor(public dialogRef: MatDialogRef<PrintingEditionsEditDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: PrintingEditionModel,
              private store: Store<AdministratorState>) {
  }

  nameControl = new FormControl('', {
    validators: [Validators.required]
  });

  ngOnInit() {

  }

  edit() {
    if (this.nameControl.valid) {
      this.store.dispatch(new EditAuthorAction({
        id: this.data.id,
        name: this.nameControl.value,
        products: null
      }));
      this.dialogRef.close();
    }
  }
}
