import {apiClient} from "./ApiClient";
import {CategoryModel} from "./Models/dto/dto";

export const getCategory = async (): Promise<CategoryModel[]> => {
  const response = await apiClient.get<CategoryModel[]>(
    "/api/Categories"
  );
  return response.data;
};