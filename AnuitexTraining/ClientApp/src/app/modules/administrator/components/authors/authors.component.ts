import {Component} from "@angular/core";

@Component({
  selector: 'administrator-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent {
  //dataSource: AuthorModel[]
  displayedColumns = ["id","name", "product", "actions"];
}
