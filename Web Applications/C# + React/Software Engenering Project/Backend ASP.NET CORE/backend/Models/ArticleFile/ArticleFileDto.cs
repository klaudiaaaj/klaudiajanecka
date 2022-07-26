using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class GetArticleFileDto
    {
        public int Id { get; set; }
        public GetArticleDtoResponse Article { get; set; }
    }


    public class PostArticleFileDto
    {
        [Required]
        public IFormFile File { get; set; }

        public int ArticleId { get; set; }
    }

    public class PutArticleFileDto
    {
        public IFormFile File { get; set; }
    }
}
