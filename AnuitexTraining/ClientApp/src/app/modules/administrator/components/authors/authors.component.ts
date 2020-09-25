import {AfterViewInit, Component} from "@angular/core";
import {AuthorModel} from "../../models/author.model";
import {MatDialog} from "@angular/material/dialog";
import {AuthorsAddDialogComponent} from "./dialogs/add/authors-add-dialog.component";
import {AdministratorState} from "../../models/administrator.state";
import {Store} from "@ngrx/store";
import {GetAuthorsAction, GetAuthorsSuccess, GetAuthorsSuccessAction} from "../../store/administrator.actions";
import {Actions, ofType} from "@ngrx/effects";
import {GetAuthorsSuccessModel} from "../../models/get-authors-success.model";

@Component({
  selector: 'administrator-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements AfterViewInit{
  constructor(private dialog: MatDialog,
              private store: Store<AdministratorState>,
              private actions$: Actions) {
  }

  dataSource: AuthorModel[]
  displayedColumns = ["id", "name", "product", "actions"];
  length: number

  edit(element) {

  }

  delete(element) {

  }

  add() {
    this.dialog.open(AuthorsAddDialogComponent);
  }

  ngAfterViewInit() {
    this.actions$.pipe(ofType(GetAuthorsSuccess)).subscribe((action: GetAuthorsSuccessAction) => {
      this.dataSource = action.payload;
      console.log(action.payload)
    });
    this.store.dispatch(new GetAuthorsAction({
      page: 1,
      pageSize: 5,
      sortField: null,
      sortOrder: null
    }))
  }


}
