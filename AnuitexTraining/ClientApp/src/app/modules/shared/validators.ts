import {FormControl} from "@angular/forms";

export function checkContainsUpper(control: FormControl) {
  let result = control.value.match(/[A-Z]/);
  if (result == null && control.value != "") {
    return { notHaveUpper: true };
  }
  return null;
}

export function checkContainsSpecialCharacter(control: FormControl) {
  let result = control.value.match(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/);
  if (result == null && control.value != "") {
    return { notHaveSpecialCharacter: true };
  }
  return null;
}

export function checkContainsLength(control: FormControl) {
  if (control.value.length >= 6 || control.value == ""){
    return null;
  }
  return { notHaveLength: true };
}

export function checkContainsNumeric(control: FormControl) {
  let result = control.value.match(/\d+/g);
  if (result == null && control.value != "") {
    return { notHaveNumeric: true };
  }
  return null;
}
