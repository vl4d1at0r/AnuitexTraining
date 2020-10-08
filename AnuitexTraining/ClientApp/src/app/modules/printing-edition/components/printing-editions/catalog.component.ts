import {AfterViewInit, Component, ViewChild} from "@angular/core";
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
import {FormControl} from "@angular/forms";
import {PrintingEditionModel} from "../../../administrator/models/printing-edition.model";

@Component({
  selector: 'printing-edition-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements AfterViewInit{

  constructor(private store: Store<AdministratorState>,
              private actions$: Actions) {
  }

  currencyControl = new FormControl();

  currencies = CurrencyTypeEnum;
  currencyOptions = Object.keys(CurrencyTypeEnum).filter(item => isNaN(Number(item)) && item != "None")

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

  sliderOptions: Options = {
    floor: 1,
    ceil: 100,
    step: 0.01,
    translate: () => '',
    getPointerColor: () => '#673ab7',
    getSelectionBarColor: () => '#673ab7'
  }

  minPrice = 1;
  maxPrice = 100;
  length: number;
  dataSource: PrintingEditionModel[];

  ngAfterViewInit() {
    this.actions$.pipe(ofType(GetPrintingEditionsSuccess)).subscribe((action: GetPrintingEditionsSuccessAction) => {
      this.dataSource = action.payload.data;
      this.length = action.payload.length;
    });

    merge().subscribe(() => {
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
      sortField: '',
      sortOrder: SortOrderEnum[''],
      filter: {
        authors: [],
        currency: CurrencyTypeEnum.USD,
        description: "",
        id: 0,
        price: 0,
        title: "",
        types: undefined
      }
    }))
  }
}
