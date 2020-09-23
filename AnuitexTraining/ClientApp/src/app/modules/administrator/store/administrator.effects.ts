import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {
  AdministratorFailAction, DeleteUser, DeleteUserAction,
  DeleteUserSuccessAction,
  GetUsers,
  GetUsersAction,
  GetUsersSuccessAction
} from "./administrator.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {AdministratorService} from "../services/administrator.service";
import {UserState} from "../../user/models/user.state";
import {of} from "rxjs";
import {UpdateUser, UpdateUserAction} from "../../user/store/user.actions";
import {GetUsersSuccessModel} from "../models/get-users-success.model";

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
}
