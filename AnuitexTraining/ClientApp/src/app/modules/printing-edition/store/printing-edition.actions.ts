import {Action} from "@ngrx/store";
import {PrintingEditionModel} from "../../administrator/models/printing-edition.model";

export const GetPrintingEdition = "[Printing Edition] Get Printing Edition";
export const GetPrintingEditionSuccess = "[Printing Edition] Get Printing Edition Success";
export const GetPrintingEditionFail = "[Printing Edition] Get Printing Edition Fail";

export class GetPrintingEditionAction implements Action {
  readonly type = GetPrintingEdition;
  constructor(public payload: number) {
  }
}

export class GetPrintingEditionSuccesAction implements Action {
  readonly type = GetPrintingEditionSuccess;
  constructor(public payload: PrintingEditionModel) {
  }
}

export class GetPrintingEditionFailAction implements Action {
  readonly type = GetPrintingEditionFail;
}

export type PrintingEditionActions = GetPrintingEditionAction | GetPrintingEditionSuccesAction | GetPrintingEditionFailAction;
