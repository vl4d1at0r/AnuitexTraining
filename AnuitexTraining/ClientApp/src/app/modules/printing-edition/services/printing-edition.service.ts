import {HttpClient} from "@angular/common/http";

export class PrintingEditionService {
  constructor(private http: HttpClient) {
  }

  url = "/api/printingEditions/";

  getPrintingEdition(id: number) {
    return this.http.get(this.url + "get/" + id);
  }
}
