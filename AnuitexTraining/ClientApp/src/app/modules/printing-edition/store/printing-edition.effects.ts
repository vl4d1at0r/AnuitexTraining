import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {PrintingEditionService} from "../services/printing-edition.service";
import {
  GetPrintingEdition,
  GetPrintingEditionAction,
  GetPrintingEditionFailAction,
  GetPrintingEditionSuccesAction
} from "./printing-edition.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {PrintingEditionModel} from "../../administrator/models/printing-edition.model";
import {of} from "rxjs";

@Injectable()
export class PrintingEditionEffects {
  constructor(private actions$: Actions,
              private printingEditionService: PrintingEditionService) {
  }

  @Effect()
  getPrintingEdition$ = this.actions$.pipe(ofType(GetPrintingEdition),
    mergeMap((action: GetPrintingEditionAction) => {
      return this.printingEditionService.getPrintingEdition(action.payload)
        .pipe(
          map((data: PrintingEditionModel) => {
            return new GetPrintingEditionSuccesAction(data);
          }),
          catchError((error => {
            return of(new GetPrintingEditionFailAction());
          }))
        )
    }))
}
