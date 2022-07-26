using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class GetArticleDtoRequest
    {
        public ArticleStatus? Status { get; set; } = null;
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
  
    }

    public class GetArticleDtoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ArticleStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ArticleFileId { get; set; }
        public GetUserDto Author { get; set; }
        public int AuthorId { get; set; }
        public GetCategoryDto Category { get; set; }
    }

    public class PostArticleDto
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }

    public class PutArticleDto
    {
        public string Title { get; set; }
        public ArticleStatus Status { get; set; }
        public int CategoryId { get; set; }
    }
}
