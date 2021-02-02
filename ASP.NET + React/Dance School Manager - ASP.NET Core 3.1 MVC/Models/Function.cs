using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class Function
    {
        public Function()
        {
            Dancers = new HashSet<Dancer>();
        }

        public int FunctionId { get; set; }
        public string FunctionName { get; set; }

        public virtual ICollection<Dancer> Dancers { get; set; }
    }
}
