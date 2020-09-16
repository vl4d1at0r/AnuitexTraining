import {Injectable} from "@angular/core";
import {Actions, Effect, ofType} from "@ngrx/effects";
import {UserService} from "../services/user.service";
import {
  GetUser,
  GetUserAction,
  GetUserSuccessAction,
  UpdateUser,
  UpdateUserAction, UpdateUserSuccessAction, UserFail,
  UserFailAction
} from "./user.actions";
import {catchError, map, mergeMap} from "rxjs/operators";
import {UserState} from "../models/user.state";
import {of} from "rxjs";
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable()
export class UserEffects {
  constructor(private actions$: Actions,
              private userService: UserService,
              private snackBar: MatSnackBar) {
  }

  @Effect()
  getUser$ = this.actions$.pipe(ofType(GetUser),
    mergeMap((action: GetUserAction) => {
      return this.userService.getUser(action.payload)
        .pipe(
          map((data: UserState) => {
            return new GetUserSuccessAction(data)
          }),
          catchError(error => {
            if (error.error != null) {
              return of(new UserFailAction(error.error))
            }
            return of()
          })
        )
    })
  );

  @Effect()
  updateUser$ = this.actions$.pipe(ofType(UpdateUser),
    mergeMap((action: UpdateUserAction) => {
      return this.userService.updateUser(action.payload)
        .pipe(
          map((result) => {
            return new UpdateUserSuccessAction(action.payload);
          }),
          catchError(error => {
            if (error.error != null)
              return of(new UserFailAction(error.error))
            return of()
          })
        )
    }));

  @Effect()
  showErrors$ = this.actions$.pipe(ofType(UserFail),
    mergeMap((action: UserFailAction) => {
      this.snackBar.open(action.payload.Errors.join(" "), "Ok", {
        horizontalPosition: "end",
        verticalPosition: "top",
        panelClass: 'snackbar'
      });
      return of();
    }))
}
