import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {AdministratorFailAction, GetUsers, GetUsersAction, GetUsersSuccessAction} from "./administrator.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {AdministratorService} from "../services/administrator.service";
import {UserState} from "../../user/models/user.state";
import {of} from "rxjs";
import {GetUsersSuccessModel} from "../models/get-users-success.model";

@Injectable()
export class AdministratorEffects {
  constructor(private actions$: Actions,
              private administratorService: AdministratorService) {
  }

  @Effect()
  getUsers$ = this.actions$.pipe(ofType(GetUsers),
    mergeMap((action: GetUsersAction) => {
      return this.administratorService.getUsers()
        .pipe(
          map((data: UserState[]) => {
            return new GetUsersSuccessAction(data);
          }),
          catchError(error => {
            return of(new AdministratorFailAction((error.error)));
          })
        )
    }))
}
