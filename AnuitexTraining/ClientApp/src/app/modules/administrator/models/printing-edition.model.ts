import {PrintingEditionCategoryEnum} from "../../shared/enums/printing-edition-category.enum";

export interface PrintingEditionModel {
  id: number,
  title: string,
  description: string,
  type: PrintingEditionCategoryEnum,
  authors: string[],
  price: number
}
