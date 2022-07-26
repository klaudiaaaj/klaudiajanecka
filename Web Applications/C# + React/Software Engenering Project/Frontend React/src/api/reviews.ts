import {apiClient} from "./ApiClient";
import {GetReviewDto, PostReviewDto, PutReviewDto} from "./Models/dto/dto";

export const getReviews = async (): Promise<GetReviewDto[]> => {
  const response = await apiClient.get<GetReviewDto[]>(
    `/api/`
  );
  return response.data;
};

export const getReview = async (id: string): Promise<GetReviewDto> => {
  const response = await apiClient.get<GetReviewDto>(
    `/api/${id}`
  );
  return response.data;
};

export const postReview = async (data: PostReviewDto): Promise<PostReviewDto> => {
  const response = await apiClient.post(
    "/api/", data,
  );
  return response.data;
};

export const deleteReview = async (id: string): Promise<GetReviewDto> => {
  const response = await apiClient.delete<GetReviewDto>(
    `/api/${id}`
  );
  return response.data;
};

export const putReview = async (id: string, data: PutReviewDto): Promise<PutReviewDto> => {
  const response = await apiClient.put(
    `/api/${id}`, data,
  );
  return response.data;
};


