import {GetPageSuccessModel} from "./get-page-success.model";
import {PrintingEditionModel} from "./printing-edition.model";

export interface GetPrintingEditionPageSuccesModel extends GetPageSuccessModel<PrintingEditionModel>{
  minPrice: number,
  maxPrice: number
}
