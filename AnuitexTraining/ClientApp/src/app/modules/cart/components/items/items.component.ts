import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {AuthorModel} from "../../../administrator/models/author.model";

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ItemsComponent>) { }

  ngOnInit() {
  }

}
