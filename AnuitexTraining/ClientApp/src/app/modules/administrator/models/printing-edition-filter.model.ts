import {PrintingEditionTypeEnum} from "../../shared/enums/printing-edition-type.enum";
import {CurrencyTypeEnum} from "../../shared/enums/currency-type.enum";

export interface PrintingEditionFilterModel {
  id: number,
  title: string,
  description: string,
  types: PrintingEditionTypeEnum[],
  authors: string[],
  minPrice: number,
  maxPrice: number,
  currency: CurrencyTypeEnum,
  searchString: string
}
