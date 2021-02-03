import {
  MyArticleResponse,
  ArticleResponse,
  LoginUserDto,
  PostArticleDto,
  RegisterUserDto,
  ServiceResponse,
  GetArticleDtoResponse
} from "./Models/dto/dto";
import {apiClient} from "./ApiClient";

export const getArticles = async (): Promise<GetArticleDtoResponse[]> => {
  const response = await apiClient.get<GetArticleDtoResponse[]>(
    "/api/Articles"
  );
  return response.data;
};

export const getPublishedArticles = async (): Promise<GetArticleDtoResponse[]> => {
  const response = await apiClient.get<GetArticleDtoResponse[]>(
    "/api/Articles?Status=4"    
  );
  return response.data;
};


export const getArticlesPreview = async (): Promise<GetArticleDtoResponse[]> => {
  const response = await apiClient.get<GetArticleDtoResponse[]>(
    "/api/Articles/preview"
  );
  return response.data;
};
 export const getArticlesByCategory = async (id: number): Promise<GetArticleDtoResponse[]> => {
  const response = await apiClient.get<GetArticleDtoResponse[]>("/api/Articles", {
    params: {
      'CategoryId' : id,
      'Status'    : 4, 
    },
      });
  return response.data;
};
export const getArticlesByAuthorId = async (id: number): Promise<MyArticleResponse[]> => {
  const response = await apiClient.get<MyArticleResponse[]>("/api/Articles", {
    params: {
      'AuthorId' : id,
    },
      });
  return response.data;
};

export const getArticlesById = async (id: number): Promise<MyArticleResponse[]> => {
  const response = await apiClient.get<MyArticleResponse[]>(
      `/api/Articles/${id}`
  );
  return response.data;
};

export const postArticle = async (data: PostArticleDto): Promise<ArticleResponse> => {
  const response = await apiClient.post(
    "/api/Articles", data,
  );
  return response.data;
};

export const postRegister = async (data: RegisterUserDto): Promise<RegisterUserDto> => {
  const response = await apiClient.post(
    "/api/Auth/Register", data,
  );
  return response.data;
};

export const postLogin = async (data: LoginUserDto): Promise<ServiceResponse<string>> => {
  const response = await apiClient.post(
    "/api/Auth/Login", data,
  );
  return response.data;
};


export const postArticleFile = async (file: File, id: number): Promise<void> => {
  const formData = new FormData();
  formData.append("file", file);
  formData.append("ArticleId", id.toString());
  await apiClient.post("/api/ArticleFiles", formData, {
    headers: {
      "Content-Type": "multipart/form-data",
    },
  });
};

export const getArticleFile = async (id: number): Promise<string> => {
  const response = await apiClient.get(`/api/ArticleFiles/${id}`, {
    headers: {
      'Accept': 'application/pdf',
    },
    responseType: 'blob',
  });
  return response.data;
}





  