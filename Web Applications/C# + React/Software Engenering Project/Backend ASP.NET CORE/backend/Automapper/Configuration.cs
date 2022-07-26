using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using AutoMapper;

namespace backend.Automapper
{
    public class Configuration: Profile
    {
        public Configuration()
        {
            CreateMap<Article, GetArticleDtoResponse>()
                .ForMember(dest => dest.ArticleFileId, opt => opt.MapFrom(src => src.ArticleFile.Id))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));

            CreateMap<Article, PostArticleDto>();
            CreateMap<PostArticleDto, Article>();
            CreateMap<Article, PutArticleDto>();
            CreateMap<PutArticleDto, Article>();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, UserInfoDto>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<PtCategoryDto, Category>();
            CreateMap<PtCategoryDto, Category>();

            CreateMap<ArticleFile, GetArticleFileDto>();
            CreateMap<PostArticleFileDto, ArticleFile>();
            CreateMap<PutArticleFileDto, ArticleFile>();

            CreateMap<Review, GetReviewDto>();
            CreateMap<PtReviewDto, Review>();
            CreateMap<PtReviewDto, Review>();

            CreateMap<ArticleReviewerDto, ArticleReviewer>();

        }
    }
}
