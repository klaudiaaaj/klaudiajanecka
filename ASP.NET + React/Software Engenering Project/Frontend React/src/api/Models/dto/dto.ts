export interface PostArticleDto {
  title: string;
  status: Status;
  categoryId: number | undefined;
}

export interface PutArticleDto {
  id: number;
  title: string;
  categoryId: number;
  status: Status;
}

export interface CategoryModel {
  id: number;
  title: string;
}

export interface GetCategoryDto {
  id: number;
  title: string;
}

export interface ArticleResponse {
  id: number;
  title: string;
  status: Status;
  createdAt: Date;
  articleFileId: number;
  categoryId: number;
}

export interface MyArticleResponse {
  id: number;
  title: string;
  status: Status;
  createdAt: Date;
  articleFileId: number;
  authorId: number;
  categoryId: number;
}
export interface GetArticleDtoResponse {
  id: number;
  title: string;
  authorId: number;
  articleStatus: Status;
  createdAt: Date;
  articleFileId: number;
  author: GetUserDto;
  category: GetCategoryDto;
}
export enum Status {
  // SentToReview = "Send to review",
  SentToReview = 0,
  Accepted = 1,
  Rejected = 2,
  Published = 3
}

export interface RegisterUserDto {
  FirstName: string;
  LastName: string;
  EmailAddress: string;
  OrcId: string;
  Password: string;
  isAuthor: boolean;
  isReviewer: boolean;
  categoriesId: Array<number>;
}

export interface LoginUserDto {
  EmailAddress: string;
  Password: string;
}

export interface GetReviewDto {
  Id: number;
  ArticleId: number;
  ReviewerId: number;
  Score: number;
}

export interface PutReviewDto {
  Score: number;
}

export interface PostReviewDto {
  ArticleId: number;
  ReviewerId: number;
  Score: number;
}



export interface GetUserDto {
  Id: number;
  firstName: string;
  lastName: string;
  emailAddress: string;
  orcId: string;
  isAuthor: boolean;
  isReviewer: boolean;
}

export interface ServiceResponse<T> {
  data: T;
  success: boolean;
  message: string | null;
}
