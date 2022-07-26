using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Orcid
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string OrcId { get; set; }
    }
}
