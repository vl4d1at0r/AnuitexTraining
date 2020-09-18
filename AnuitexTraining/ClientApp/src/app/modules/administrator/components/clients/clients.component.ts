import {AfterViewInit, Component, OnInit, ViewChild} from "@angular/core";
import {UserState} from "../../../user/models/user.state";
import {MatSort} from "@angular/material/sort";
import {Store} from "@ngrx/store";
import {AdministratorState} from "../../models/administrator.state";
import {GetUsersAction} from "../../store/administrator.actions";
import {getUsersSelector} from "../../store/administrator.selectors";
import {merge} from "rxjs";
import {MatPaginator} from "@angular/material/paginator";
import {map, startWith, switchMap} from "rxjs/operators";

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
export class ClientsComponent implements OnInit,AfterViewInit {
  constructor(private store: Store<AdministratorState>) {
  }

  dataSource: UserState[]

  displayedColumns: string[] = ['username', 'email', 'enabled', 'actions'];

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;

  ngOnInit() {
    this.store.dispatch(new GetUsersAction());
    this.store.select(getUsersSelector).subscribe(item => {
      this.dataSource = item
    });
  }

  ngAfterViewInit() {
    console.log(this.paginator, this.sort);
    merge(this.sort.sortChange, this.paginator.page, )
  }
}
