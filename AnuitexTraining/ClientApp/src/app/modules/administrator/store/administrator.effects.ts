import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {
  AddAuthor, AddAuthorAction, AddAuthorSuccessAction,
  AdministratorFailAction,
  DeleteUser,
  DeleteUserAction,
  DeleteUserSuccessAction, GetAuthors, GetAuthorsAction, GetAuthorsSuccessAction,
  GetUsers,
  GetUsersAction, GetUsersSuccessAction
} from "./administrator.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {AdministratorService} from "../services/administrator.service";
import {of} from "rxjs";
import {GetUsersSuccessModel} from "../models/get-users-success.model";
import {GetAuthorsSuccessModel} from "../models/get-authors-success.model";

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
          map((data: GetUsersSuccessModel) => {
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
          map((data: GetAuthorsSuccessModel) => {
            return new GetAuthorsSuccessAction(data);
          }),
          catchError(error => {
            return of(new AdministratorFailAction(error.error));
          })
        )
    }))
}
