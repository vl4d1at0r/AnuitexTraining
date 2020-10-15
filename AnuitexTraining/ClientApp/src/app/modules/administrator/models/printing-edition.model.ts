import {PrintingEditionTypeEnum} from "../../shared/enums/printing-edition-type.enum";
import {CurrencyTypeEnum} from "../../shared/enums/currency-type.enum";

export interface PrintingEditionModel {
  id: number,
  title: string,
  description: string,
  type: PrintingEditionTypeEnum,
  authors: string[],
  price: number,
  currency: CurrencyTypeEnum
}
