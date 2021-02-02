using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class Dancer
    {
        public Dancer()
        {
            GroupHasDancers = new HashSet<GroupHasDancer>();
        }

        public int DancerId { get; set; }
        public int FunctionId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }

        public virtual Function Function { get; set; }
        public virtual ICollection<GroupHasDancer> GroupHasDancers { get; set; }
    }
}
