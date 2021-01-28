using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class DanceStyle
    {
        public DanceStyle()
        {
            Groups = new HashSet<Group>();
        }

        public int DancestyleId { get; set; }
        public string DancestyleName { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
