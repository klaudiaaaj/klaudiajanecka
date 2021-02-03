using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{ 
    public class CategoryReviewer
    {
        public int id { get; set;  }
        public int userId { get; set; }
        public int categoryId { get; set; }
    }
}
