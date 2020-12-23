using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class Hour
    {
        public Hour()
        {
            Classes = new HashSet<Class>();
        }

        public int HourId { get; set; }
        public int? HourStart { get; set; }
        public int? HourEnd { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
