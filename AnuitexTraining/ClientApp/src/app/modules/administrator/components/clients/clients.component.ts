import {AfterViewInit, Component, OnInit, ViewChild} from "@angular/core";
import {MatTableDataSource} from "@angular/material/table";
import {UserState} from "../../../user/models/user.state";
import {MatSort} from "@angular/material/sort";

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
export class ClientsComponent implements AfterViewInit{
  dataSource: MatTableDataSource<UserState[]>

  displayedColumns: string[] = ['username', 'email', 'enabled', 'actions'];

  ngAfterViewInit() {
  }
}
