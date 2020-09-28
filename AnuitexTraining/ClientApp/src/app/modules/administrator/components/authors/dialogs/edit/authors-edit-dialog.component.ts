import {Component, Inject, OnInit} from "@angular/core";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AuthorModel} from "../../../../models/author.model";
import {FormControl, Validators} from "@angular/forms";
import {AdministratorState} from "../../../../models/administrator.state";
import {Store} from "@ngrx/store";
import {AddAuthorAction, EditAuthorAction} from "../../../../store/administrator.actions";

@Component({
  selector: 'authors-edit-dialog',
  templateUrl: './authors-edit-dialog.component.html',
  styleUrls: ['./authors-edit-dialog.component.css']
})
export class AuthorsEditDialogComponent implements OnInit{
  constructor(public dialogRef: MatDialogRef<AuthorsEditDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: AuthorModel,
              private store: Store<AdministratorState>) {
  }

  nameControl = new FormControl('', {
    validators: [Validators.required]
  });

  ngOnInit() {
    this.nameControl.setValue(this.data.name)
  }

  edit() {
    if (this.nameControl.valid) {
      this.store.dispatch(new EditAuthorAction({
        id: this.data.id,
        name: this.nameControl.value,
        product: null
      }));
      this.dialogRef.close();
    }
  }
}
