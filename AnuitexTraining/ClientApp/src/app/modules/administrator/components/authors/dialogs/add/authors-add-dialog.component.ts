import {Component} from "@angular/core";
import {MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../../../models/administrator.state";
import {AddAuthorAction} from "../../../../store/administrator.actions";

@Component({
  selector: 'authors-add-dialog',
  templateUrl: './authors-add-dialog.component.html',
  styleUrls: ['./authors-add-dialog.component.css']
})
export class AuthorsAddDialogComponent {
  constructor(public dialogRef: MatDialogRef<AuthorsAddDialogComponent>,
              private store: Store<AdministratorState>) {
  }

  nameControl = new FormControl('', {
    validators: [Validators.required]
  });

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
