import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { AccountService } from "../services/account.service";
import { SignIn, SignInAction, SignInSuccessAction, SignInFailAction } from "./account.actions";
import { map, mergeMap, catchError } from 'rxjs/operators';
import { SignInSuccessModel } from "../models/sign-in-success.model";
import { SignInFailModel } from "../models/sign-in-fail.model";
import { of } from "rxjs";

@Injectable()
export class AccountEffects {
    constructor(private actions$: Actions, private signInService: AccountService) {}

    @Effect()
    signIn$ = this.actions$.pipe(ofType(SignIn),
        mergeMap((action: SignInAction) => {
            return this.signInService.signIn(action.payload.email, action.payload.password)
                .pipe(
                    map((data: SignInSuccessModel) => new SignInSuccessAction(data)),
                    catchError(error => {console.log(error); return of(new SignInFailAction(error.error))})
                );
        })
    )
}