import {AfterViewInit, Component, OnInit, ViewChild} from "@angular/core";
import {UserState} from "../../../user/models/user.state";
import {MatSort} from "@angular/material/sort";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../models/administrator.state";
import {DeleteUserAction, DeleteUserSuccess, GetUsersAction, GetUsersSuccess} from "../../store/administrator.actions";
import {getAdministratorSelector, getUsersSelector} from "../../store/administrator.selectors";
import {merge} from "rxjs";
import {MatPaginator} from "@angular/material/paginator";
import {MatDialog} from "@angular/material/dialog";
import {EditDialogComponent} from "./dialogs/edit/edit-dialog.component";
import {UpdateUserAction, UpdateUserSuccess} from "../../../user/store/user.actions";
import {Actions, ofType} from "@ngrx/effects";
import {SortOrderEnum} from "../../../shared/enums/sort-order.enum";

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
  displayedColumns: string[] = ['username', 'Email', 'enabled', 'actions'];

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
    isBlocked: null
  };
  userFilter = false;
  statusFilter = false;
  length = 0;

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.actions$.pipe(ofType(UpdateUserSuccess, DeleteUserSuccess)).subscribe(() => {
      this.paginator.firstPage();
      this.administratorStore.dispatch(new GetUsersAction({
        filter: this.filter,
        page: this.paginator.pageIndex + 1,
        pageSize: this.paginator.pageSize,
        sortField: this.sort.active,
        sortOrder: SortOrderEnum[this.sort.direction]
      }));
    })

    this.actions$.pipe(ofType(GetUsersSuccess)).subscribe(() => {
      this.administratorStore.select(getAdministratorSelector).subscribe(item => {
        this.dataSource = item.users;
        this.length = item.length
      });
    })
    this.administratorStore.dispatch(new GetUsersAction({
      filter: this.filter,
      page: this.paginator.pageIndex + 1,
      pageSize: this.paginator.pageSize,
      sortField: this.sort.active,
      sortOrder: SortOrderEnum[this.sort.direction]
    }));

    merge(this.sort.sortChange).subscribe(() => {
      this.paginator.firstPage();
      this.administratorStore.dispatch(new GetUsersAction({
        filter: this.filter,
        page: this.paginator.pageIndex + 1,
        pageSize: this.paginator.pageSize,
        sortField: this.sort.active,
        sortOrder: SortOrderEnum[this.sort.direction]
      }));
    })

    this.paginator.page.subscribe(() => {
      this.administratorStore.dispatch(new GetUsersAction({
        filter: this.filter,
        page: this.paginator.pageIndex + 1,
        pageSize: this.paginator.pageSize,
        sortField: this.sort.active,
        sortOrder: SortOrderEnum[this.sort.direction]
      }));
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
