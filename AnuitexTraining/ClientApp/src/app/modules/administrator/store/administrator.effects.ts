import {Injectable} from "@angular/core";
import {act, Actions, Effect, ofType} from "@ngrx/effects";
import {
  AddAuthor,
  AddAuthorAction,
  AddAuthorSuccessAction,
  AdministratorFailAction, DeleteAuthor, DeleteAuthorAction, DeleteAuthorSuccessAction,
  DeleteUser,
  DeleteUserAction,
  DeleteUserSuccessAction,
  EditAuthor,
  EditAuthorAction,
  EditAuthorSuccessAction,
  GetAuthors,
  GetAuthorsAction,
  GetAuthorsSuccessAction,
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
}
