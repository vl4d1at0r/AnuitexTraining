import {AfterViewInit, Component, ViewChild} from "@angular/core";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {PrintingEditionModel} from "../../models/printing-edition.model";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../models/administrator.state";
import {Actions, ofType} from "@ngrx/effects";
import {
  AddAuthorSuccess,
  DeleteAuthorSuccess,
  EditAuthorSuccess,
  GetAuthorsSuccess,
  GetAuthorsSuccessAction,
  GetPrintingEditions,
  GetPrintingEditionsAction,
  GetPrintingEditionsSuccess,
  GetPrintingEditionsSuccessAction
} from "../../store/administrator.actions";
import {merge} from "rxjs";

@Component({
  selector: 'administrator-printing-editions',
  templateUrl: './printing-editions.component.html',
  styleUrls: ['./printing-editions.component.css']
})
export class PrintingEditionsComponent implements AfterViewInit {
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  dataSource: PrintingEditionModel[];
  displayedColumns: string[] = ['id', 'name', 'description', 'category', 'author', 'price', 'actions'];
  length: number;

  constructor(private store: Store<AdministratorState>,
              private actions$: Actions) {
  }

  edit(element) {

  }

  delete(element) {

  }

  add() {

  }

  ngAfterViewInit() {
    this.actions$.pipe(ofType(GetPrintingEditionsSuccess)).subscribe((action: GetPrintingEditionsSuccessAction) => {
      this.dataSource = action.payload.data;
      this.length = action.payload.length;
    });

    merge(this.sort.sortChange, this.actions$.pipe(ofType(DeleteAuthorSuccess, EditAuthorSuccess, AddAuthorSuccess))).subscribe(() => {
      this.paginator.firstPage();
      this.getPrintingEditions()
    });

    this.paginator.page.subscribe(() => {
      this.getPrintingEditions();
    });

    this.getPrintingEditions()
  }

  getPrintingEditions() {
    this.store.dispatch(new GetPrintingEditionsAction(null))
  }
}
