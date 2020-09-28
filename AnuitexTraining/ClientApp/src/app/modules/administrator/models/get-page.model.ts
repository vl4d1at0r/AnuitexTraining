import {UserState} from "../../user/models/user.state";
import {SortOrderEnum} from "../../shared/enums/sort-order.enum";

export interface GetPageModel<T> {
  sortField: string,
  sortOrder: SortOrderEnum,
  page: number,
  pageSize: number,
  filter: T
}
