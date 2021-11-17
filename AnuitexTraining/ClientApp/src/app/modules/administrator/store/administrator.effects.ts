import {Injectable} from "@angular/core";
import {act, Actions, Effect, ofType} from "@ngrx/effects";
import {
  AddAuthor,
  AddAuthorAction,
  AddAuthorSuccessAction,
  AddPrintingEdition,
  AddPrintingEditionAction,
  AddPrintingEditionSuccessAction,
  AdministratorFailAction,
  DeleteAuthor,
  DeleteAuthorAction,
  DeleteAuthorSuccessAction,
  DeletePrintingEdition,
  DeletePrintingEditionAction, DeletePrintingEditionSuccessAction,
  DeleteUser,
  DeleteUserAction,
  DeleteUserSuccessAction,
  EditAuthor,
  EditAuthorAction,
  EditAuthorSuccessAction, EditPrintingEdition, EditPrintingEditionAction, EditPrintingEditionSuccessAction,
  GetAuthors,
  GetAuthorsAction,
  GetAuthorsSuccessAction, GetOrders, GetOrdersAction, GetOrdersSuccessAction,
  GetPrintingEditions,
  GetPrintingEditionsAction,
  GetPrintingEditionsSuccessAction,
  GetUsers,
  GetUsersAction,
  GetUsersSuccessAction
} from "./administrator.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {AdministratorService} from "../services/administrator.service";
import {of} from "rxjs";
import {GetPageSuccessModel} from "../models/get-page-success.model";
import {AuthorModel} from "../models/author.model";
import {UserState} from "../../user/models/user.state";
import {PrintingEditionModel} from "../models/printing-edition.model";
import {GetPrintingEditionPageSuccesModel} from "../models/get-printing-edition-page-succes.model";
import {OrderModel} from "../../cart/models/order.model";

@Injectable()
export class AdministratorEffects {
  constructor(private actions$: Actions,
              private administratorService: AdministratorService) {
  }

  @Effect()
  getUsers$ = this.actions$.pipe(ofType(GetUsers),
    mergeMap((action: GetUsersAction) => {
      return this.administratorService.getUsers(action.payload)
        .pipe(
          map((data: GetPageSuccessModel<UserState>) => {
            return new GetUsersSuccessAction(data);
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  deleteUser$ = this.actions$.pipe(ofType(DeleteUser),
    mergeMap((action: DeleteUserAction) => {
      return this.administratorService.deleteUser(action.payload)
        .pipe(
          map(() => {
            return new DeleteUserSuccessAction();
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  addAuthor$ = this.actions$.pipe(ofType(AddAuthor),
    mergeMap((action: AddAuthorAction) => {
      return this.administratorService.addAuthor(action.payload)
        .pipe(
          map(() => {
            return new AddAuthorSuccessAction();
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  getAuthors$ = this.actions$.pipe(ofType(GetAuthors),
    mergeMap((action: GetAuthorsAction) => {
      return this.administratorService.getAuthors(action.payload)
        .pipe(
          map((data: GetPageSuccessModel<AuthorModel>) => {
            return new GetAuthorsSuccessAction(data);
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  editAuthor$ = this.actions$.pipe(ofType(EditAuthor),
    mergeMap((action: EditAuthorAction) => {
      return this.administratorService.editAuthor(action.payload)
        .pipe(
          map(() => {
            return new EditAuthorSuccessAction();
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  deleteAuthor$ = this.actions$.pipe(ofType(DeleteAuthor),
    mergeMap((action: DeleteAuthorAction) => {
      return this.administratorService.deleteAuthor(action.payload)
        .pipe(
          map(() => {
            return new DeleteAuthorSuccessAction();
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  getPrintingEditions$ = this.actions$.pipe(ofType(GetPrintingEditions),
    mergeMap((action: GetPrintingEditionsAction) => {
      return this.administratorService.getPrintingEditions(action.payload)
        .pipe(
          map((data: GetPrintingEditionPageSuccesModel) => {
            return new GetPrintingEditionsSuccessAction(data);
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  addPrintingEdition$ = this.actions$.pipe(ofType(AddPrintingEdition),
    mergeMap((action: AddPrintingEditionAction) => {
      return this.administratorService.addPrintingEdition(action.payload)
        .pipe(
          map(() => {
            return new AddPrintingEditionSuccessAction();
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  deletePrintingEdition$ = this.actions$.pipe(ofType(DeletePrintingEdition),
    mergeMap((action: DeletePrintingEditionAction) => {
      return this.administratorService.deletePrintingEdition(action.payload)
        .pipe(
          map(() => {
            return new DeletePrintingEditionSuccessAction();
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  editPrintingEdition$ = this.actions$.pipe(ofType(EditPrintingEdition),
    mergeMap((action: EditPrintingEditionAction) => {
      return this.administratorService.editPrintingEdition(action.payload)
        .pipe(
          map(() => {
            return new EditPrintingEditionSuccessAction();
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))

  @Effect()
  getOrders$ = this.actions$.pipe(ofType(GetOrders),
    mergeMap((action: GetOrdersAction) => {
      return this.administratorService.getOrders(action.payload)
        .pipe(
          map((data: GetPageSuccessModel<OrderModel>) => {
            return new GetOrdersSuccessAction(data)
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))
}
