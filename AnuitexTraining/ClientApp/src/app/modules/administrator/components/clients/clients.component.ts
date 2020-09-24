import {AfterViewInit, Component, EventEmitter, OnInit, ViewChild} from "@angular/core";
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
import {FormControl, FormGroup} from "@angular/forms";

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

  options: string[];
  filteredOptions: string[];
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

  active = true;
  blocked = true;

  searchText = "";
  refresh = new EventEmitter();

  ngOnInit() {
  }

  ngAfterViewInit() {

    this.actions$.pipe(ofType(GetUsersSuccess)).subscribe(() => {
      this.administratorStore.select(getAdministratorSelector).subscribe(item => {
        this.dataSource = item.users;
        this.length = item.length;
        this.options = item.users.map(item => item.firstName + " " + item.lastName);
        this.filteredOptions = this.options
      });
    })
    this.getUsers()

    merge(this.sort.sortChange, this.actions$.pipe(ofType(UpdateUserSuccess, DeleteUserSuccess)), this.refresh).subscribe(() => {
      this.paginator.firstPage();
      this.getUsers()
    })

    this.paginator.page.subscribe(() => {
      this.getUsers()
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

  getUsers() {
    this.administratorStore.dispatch(new GetUsersAction({
      filter: this.filter,
      page: this.paginator.pageIndex + 1,
      pageSize: this.paginator.pageSize,
      sortField: this.sort.active,
      sortOrder: SortOrderEnum[this.sort.direction]
    }));
  }

  search() {
    let names = this.searchText.split(' ');
    this.filter.firstName = names[0];
    this.filter.lastName = names[1] == null ? "" : names[1];
    this.refresh.emit();
  }

  change() {
    if (this.active == this.blocked) {
      this.filter.isBlocked = null;
    }
    else if (this.active) {
      this.filter.isBlocked = false;
    }
    else if(this.blocked) {
      this.filter.isBlocked = true;
    }
    this.refresh.emit();
  }

  searchTextChange() {
    this.filteredOptions = this.options.filter(item => {
      return item.toLowerCase().includes(this.searchText.toLowerCase());
    })
  }
}
