using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ArticleReviewer
    {
        public int? ReviewerId { get; set; }
        public User Reviewer { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
