import {AuthorModel} from "./author.model";

export interface GetPageSuccessModel<T> {
  data: T[],
  length: number
}
