import {AfterViewInit, Component, OnInit, ViewChild} from "@angular/core";
import {UserState} from "../../../user/models/user.state";
import {MatSort} from "@angular/material/sort";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../models/administrator.state";
import {
  DeleteUserAction,
  DeleteUserSuccess,
  GetUsers,
  GetUsersAction,
  GetUsersSuccess
} from "../../store/administrator.actions";
import {getUsersSelector} from "../../store/administrator.selectors";
import {merge} from "rxjs";
import {MatPaginator} from "@angular/material/paginator";
import {MatDialog} from "@angular/material/dialog";
import {EditDialogComponent} from "./dialogs/edit/edit-dialog.component";
import {UpdateUser, UpdateUserAction, UpdateUserSuccess} from "../../../user/store/user.actions";
import {Actions, ofType} from "@ngrx/effects";

@Component({
  selector: 'administrator-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit, AfterViewInit {
  constructor(private administratorStore: Store<AdministratorState>,
              private userStore: Store<UserState>,
              public dialog: MatDialog,
              private actions$: Actions) {
  }

  //dataSource$ ;
  dataSource: UserState[];
  displayedColumns: string[] = ['username', 'email', 'enabled', 'actions'];

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  filter: UserState = {
    firstName: "",
    lastName: "",
    nickName: "",
    email: "",
    password: "",
    phoneNumber: "",
    id: 0,
    creationDate: null,
    isBlocked: false
  };
  userFilter = false;
  statusFilter = false;

  ngOnInit() {
    this.actions$.pipe(ofType(UpdateUserSuccess, DeleteUserSuccess)).subscribe(() => {
      this.administratorStore.dispatch(new GetUsersAction(this.filter));
    })

    this.actions$.pipe(ofType(GetUsersSuccess)).subscribe(() => {
      this.administratorStore.select(getUsersSelector).subscribe(item => {
        this.dataSource = item
      });
    })
    this.administratorStore.dispatch(new GetUsersAction(this.filter));
  }

  ngAfterViewInit() {
    merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
      this.administratorStore.dispatch(new GetUsersAction(this.filter));
    })
  }

  statusChange(element: UserState) {
    element.isBlocked = !element.isBlocked;
    this.userStore.dispatch(new UpdateUserAction(element));
  }

  edit(element) {
    let dialogRef = this.dialog.open(EditDialogComponent, {
      data: element
    });

  }

  delete(element) {
    this.administratorStore.dispatch(new DeleteUserAction(element.id));
  }
}
