using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class PtCategoryDto
    {
        public string Title { get; set; }
    }
  
}
