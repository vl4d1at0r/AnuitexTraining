import {AfterViewInit, Component, OnInit, ViewChild} from "@angular/core";
import {UserState} from "../../../user/models/user.state";
import {MatSort} from "@angular/material/sort";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../models/administrator.state";
import {GetUsersAction} from "../../store/administrator.actions";
import {getUsersSelector} from "../../store/administrator.selectors";
import {merge} from "rxjs";
import {MatPaginator} from "@angular/material/paginator";

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'administrator-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit, AfterViewInit {
  constructor(private store: Store<AdministratorState>) {
  }

  //dataSource$ ;
  dataSource: UserState[];
  displayedColumns: string[] = ['username', 'email', 'enabled', 'actions'];

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  userFilter = false;
  statusFilter = false;

  ngOnInit() {
    this.store.dispatch(new GetUsersAction());
    this.store.select(getUsersSelector).subscribe(item => {
      this.dataSource = item
    });
  }

  ngAfterViewInit() {
    merge(this.sort.sortChange, this.paginator.page,)
  }

  statusChange(id: number) {
    this.dataSource[0].email = "";
  }
}
