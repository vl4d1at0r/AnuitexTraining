import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {MaterialModule} from "../shared/material.module";
import {ProfileComponent} from "./components/profile.component";
import {UserService} from "./services/user.service";
import {EffectsModule} from "@ngrx/effects";
import {UserEffects} from "./store/user.effects";
import {ValidateEqualModule} from "ng-validate-equal";

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    EffectsModule.forFeature([UserEffects]),
    ValidateEqualModule
  ],
  declarations: [
    ProfileComponent
  ],
  exports: [
    ProfileComponent
  ],
  providers: [
    UserService
  ]
})
export class UserModule {

}
