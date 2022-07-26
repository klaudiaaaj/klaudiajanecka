using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public enum ArticleStatus
    {
        SentToReview = 0,
        inReview  = 1,
        Accepted  = 2, 
        Rejected  = 3, 
        Published = 4
    }
}
