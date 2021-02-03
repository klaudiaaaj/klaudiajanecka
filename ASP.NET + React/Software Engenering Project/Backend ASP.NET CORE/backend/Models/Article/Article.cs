using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public ArticleStatus Status { get; set; } = ArticleStatus.SentToReview;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ArticleFile ArticleFile { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ArticleReviewer> ArticleReviewers { get; set; }
    }
}
