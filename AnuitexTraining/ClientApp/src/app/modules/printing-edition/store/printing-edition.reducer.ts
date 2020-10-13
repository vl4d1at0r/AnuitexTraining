import {PrintingEditionModel} from "../../administrator/models/printing-edition.model";
import {CurrencyTypeEnum} from "../../shared/enums/currency-type.enum";
import {PrintingEditionTypeEnum} from "../../shared/enums/printing-edition-type.enum";
import {GetPrintingEditionSuccess, PrintingEditionActions} from "./printing-edition.actions";

export const printingEditionInitialState: PrintingEditionModel = {
  id: 0,
  currency: CurrencyTypeEnum.None,
  price: 0,
  authors: [],
  title: "",
  type: PrintingEditionTypeEnum.None,
  description: ""
}

export function printingEditionReducer(state = printingEditionInitialState, action: PrintingEditionActions) {
  switch (action.type) {
    case GetPrintingEditionSuccess:
      return action.payload;
    default:
      return state;
  }
}
