using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class Group
    {
        public Group()
        {
            Classes = new HashSet<Class>();
            GroupHasDancers = new HashSet<GroupHasDancer>();
        }

        public int GroupId { get; set; }
        public int SupervisorId { get; set; }
        public string GroupName { get; set; }
        public int DancestyleId { get; set; }

        public virtual DanceStyle Dancestyle { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<GroupHasDancer> GroupHasDancers { get; set; }
    }
}
