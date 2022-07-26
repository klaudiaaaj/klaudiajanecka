using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ArticleFile
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
