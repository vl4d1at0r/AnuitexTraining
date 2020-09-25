import {AuthorModel} from "./author.model";

export interface GetAuthorsSuccessModel {
  authors: AuthorModel[],
  length: number
}
