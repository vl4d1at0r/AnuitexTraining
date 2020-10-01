import {AfterViewInit, Component, ViewChild} from "@angular/core";
import {AuthorModel} from "../../models/author.model";
import {MatDialog} from "@angular/material/dialog";
import {AuthorsAddDialogComponent} from "./dialogs/add/authors-add-dialog.component";
import {AdministratorState} from "../../models/administrator.state";
import {Store} from "@ngrx/store";
import {
  AddAuthorSuccess,
  DeleteAuthorAction,
  DeleteAuthorSuccess,
  EditAuthorSuccess,
  GetAuthorsAction,
  GetAuthorsSuccess,
  GetAuthorsSuccessAction
} from "../../store/administrator.actions";
import {Actions, ofType} from "@ngrx/effects";
import {SortOrderEnum} from "../../../shared/enums/sort-order.enum";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {AuthorsEditDialogComponent} from "./dialogs/edit/authors-edit-dialog.component";
import {merge} from "rxjs";

@Component({
  selector: 'administrator-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements AfterViewInit {
  constructor(private dialog: MatDialog,
              private store: Store<AdministratorState>,
              private actions$: Actions) {
  }

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  dataSource: AuthorModel[]
  displayedColumns = ["id", "name", "product", "actions"];
  length: number

  edit(element) {
    this.dialog.open(AuthorsEditDialogComponent, {
      data: element
    });
  }

  delete(element) {
    this.store.dispatch(new DeleteAuthorAction(element.id));
  }

  add() {
    this.dialog.open(AuthorsAddDialogComponent);
  }

  ngAfterViewInit() {
    this.actions$.pipe(ofType(GetAuthorsSuccess)).subscribe((action: GetAuthorsSuccessAction) => {
      this.dataSource = action.payload.data;
      this.length = action.payload.length;
    });

    merge(this.sort.sortChange, this.actions$.pipe(ofType(DeleteAuthorSuccess, EditAuthorSuccess, AddAuthorSuccess))).subscribe(() => {
      this.paginator.firstPage();
      this.getAuthors()
    });

    this.paginator.page.subscribe(() => {
      this.getAuthors();
    });

    this.getAuthors()
  }

  getAuthors() {
    this.store.dispatch(new GetAuthorsAction({
      page: this.paginator.pageIndex + 1,
      pageSize: this.paginator.pageSize,
      sortField: this.sort.active,
      sortOrder: SortOrderEnum[this.sort.direction],
      filter: undefined
    }))
  }

}
