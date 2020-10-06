import {AfterViewInit, Component, EventEmitter, ViewChild} from "@angular/core";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";
import {PrintingEditionModel} from "../../models/printing-edition.model";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../models/administrator.state";
import {Actions, ofType} from "@ngrx/effects";
import {
  AddAuthorSuccess, AddPrintingEditionSuccess,
  DeleteAuthorSuccess, DeletePrintingEditionAction, DeletePrintingEditionSuccess,
  EditAuthorSuccess, EditPrintingEditionSuccess,
  GetPrintingEditionsAction,
  GetPrintingEditionsSuccess,
  GetPrintingEditionsSuccessAction
} from "../../store/administrator.actions";
import {merge} from "rxjs";
import {SortOrderEnum} from "../../../shared/enums/sort-order.enum";
import {PrintingEditionFilterModel} from "../../models/printing-edition-filter.model";
import {PrintingEditionTypeEnum} from "../../../shared/enums/printing-edition-type.enum";
import {CurrencyTypeEnum} from "../../../shared/enums/currency-type.enum";
import {MatDialog} from "@angular/material/dialog";
import {PrintingEditionsEditDialogComponent} from "./dialogs/edit/printing-editions-edit-dialog.component";
import {PrintingEditionsAddDialogComponent} from "./dialogs/add/printing-editions-add-dialog.component";

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
  filter: PrintingEditionFilterModel = {
    authors: [],
    types: undefined,
    description: "",
    id: 0,
    title: "",
    price: 0,
    currency: CurrencyTypeEnum.USD
  }

  categoryFilter = false;
  book = true;
  magazine = true;
  newspaper = true
  categoryChange = new EventEmitter()


  constructor(private store: Store<AdministratorState>,
              private actions$: Actions,
              private dialog: MatDialog) {
  }

  edit(element) {
    this.dialog.open(PrintingEditionsEditDialogComponent, {data: element})
  }

  delete(element) {
    this.store.dispatch(new DeletePrintingEditionAction(element.id));
  }

  add() {
    this.dialog.open(PrintingEditionsAddDialogComponent)
  }

  ngAfterViewInit() {
    this.actions$.pipe(ofType(GetPrintingEditionsSuccess)).subscribe((action: GetPrintingEditionsSuccessAction) => {
      this.dataSource = action.payload.data;
      this.length = action.payload.length;
    });

    merge(this.categoryChange, this.sort.sortChange, this.actions$.pipe(ofType(DeletePrintingEditionSuccess, EditPrintingEditionSuccess, AddPrintingEditionSuccess))).subscribe(() => {
      this.paginator.firstPage();
      this.getPrintingEditions()
    });

    this.paginator.page.subscribe(() => {
      this.getPrintingEditions();
    });

    this.getPrintingEditions()
  }

  getPrintingEditions() {
    this.store.dispatch(new GetPrintingEditionsAction({
      page: this.paginator.pageIndex + 1,
      pageSize: this.paginator.pageSize,
      sortField: this.sort.active,
      sortOrder: SortOrderEnum[this.sort.direction],
      filter: this.filter
    }))
  }

  toEnum(type) {
    return PrintingEditionTypeEnum[type]
  }

  change() {
    this.filter.types = [];
    if (this.book) {
      this.filter.types.push(PrintingEditionTypeEnum.Book)
    }
    if (this.magazine) {
      this.filter.types.push(PrintingEditionTypeEnum.Magazine)
    }
    if (this.newspaper) {
      this.filter.types.push(PrintingEditionTypeEnum.Newspaper)
    }
    this.categoryChange.emit()
  }
}
