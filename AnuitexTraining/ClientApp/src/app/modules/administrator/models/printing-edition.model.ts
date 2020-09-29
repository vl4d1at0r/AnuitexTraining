import {PrintingEditionCategoryEnum} from "../../shared/enums/printing-edition-category.enum";

export interface PrintingEditionModel {
  id: number,
  name: string,
  description: string,
  category: PrintingEditionCategoryEnum,
  authors: string[],
  price: number
}
