using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class GetReviewDto
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int ReviewerId { get; set; }
        public float Score { get; set; }
    }

    public class PtReviewDto
    {
        public int ArticleId { get; set; }
        public float Score { get; set; }
    }
}
