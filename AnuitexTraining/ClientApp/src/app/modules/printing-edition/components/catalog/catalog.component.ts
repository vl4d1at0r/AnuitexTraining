import {AfterViewInit, Component, EventEmitter, ViewChild} from "@angular/core";
import {Options} from "ng5-slider";
import {Actions, ofType} from "@ngrx/effects";
import {
  GetPrintingEditionsAction,
  GetPrintingEditionsSuccess,
  GetPrintingEditionsSuccessAction
} from "../../../administrator/store/administrator.actions";
import {merge} from "rxjs";
import {SortOrderEnum} from "../../../shared/enums/sort-order.enum";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../../administrator/models/administrator.state";
import {MatPaginator} from "@angular/material/paginator";
import {CurrencyTypeEnum} from "../../../shared/enums/currency-type.enum";
import {PrintingEditionModel} from "../../../administrator/models/printing-edition.model";
import {PrintingEditionFilterModel} from "../../../administrator/models/printing-edition-filter.model";
import {PrintingEditionTypeEnum} from "../../../shared/enums/printing-edition-type.enum";
import {checkAdmin} from "../../../shared/common";
import {AccountState} from "../../../account/interfaces/account.state";

@Component({
  selector: 'printing-edition-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements AfterViewInit {

  constructor(private store: Store<AdministratorState>,
              private userStore: Store<AccountState>,
              private actions$: Actions) {
  }

  currencies = CurrencyTypeEnum;
  currencyOptions = Object.keys(CurrencyTypeEnum).filter(item => isNaN(Number(item)) && item != "None")
  onChange = new EventEmitter()
  currencyMarks = [
    "",
    "$",
    "€",
    "£",
    "CHF",
    "¥",
    "₴"
  ]

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

  sliderOptions: Options = {
    floor: 1,
    ceil: 100,
    step: 0.01,
    translate: () => '',
    getPointerColor: () => '#673ab7',
    getSelectionBarColor: () => '#673ab7'
  }

  filter: PrintingEditionFilterModel = {
    authors: [],
    currency: CurrencyTypeEnum.USD,
    description: "",
    id: 0,
    minPrice: 0,
    maxPrice: 0,
    title: "",
    types: undefined,
    searchString: ""
  }

  length: number;
  dataSource: PrintingEditionModel[];
  books = true;
  magazines = true;
  newspapers = true;
  priceToHigh: boolean;
  sort = SortOrderEnum.asc;
  sortOrder = SortOrderEnum;
  firstTime = true;
  isAdmin = checkAdmin(this.userStore);

  ngAfterViewInit() {
    this.actions$.pipe(ofType(GetPrintingEditionsSuccess)).subscribe((action: GetPrintingEditionsSuccessAction) => {
      this.dataSource = action.payload.data;
      this.length = action.payload.length;
      if (this.firstTime) {
        this.sliderOptions = {
          floor: action.payload.minPrice,
          ceil: action.payload.maxPrice,
          step: 0.01,
          translate: () => '',
          getPointerColor: () => '#673ab7',
          getSelectionBarColor: () => '#673ab7'
        };
        this.filter.minPrice = action.payload.minPrice;
        this.filter.maxPrice = action.payload.maxPrice;
        this.firstTime = false;
      }
    });

    merge(this.onChange).subscribe(() => {
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
      sortField: 'price',
      sortOrder: this.sort,
      filter: this.filter
    }))
  }

  change() {
    this.filter.types = [];
    if (this.books) {
      this.filter.types.push(PrintingEditionTypeEnum.Book)
    }
    if (this.magazines) {
      this.filter.types.push(PrintingEditionTypeEnum.Magazine)
    }
    if (this.newspapers) {
      this.filter.types.push(PrintingEditionTypeEnum.Newspaper)
    }
    this.onChange.emit()
  }

  sortChange() {
    this.onChange.emit()
  }

  currencyChange() {
    this.filter.minPrice = 0;
    this.filter.maxPrice = 0;
    this.firstTime = true;
    this.onChange.emit()
  }
}
