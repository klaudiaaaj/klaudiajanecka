using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class GroupHasDancer
    {
        public int GroupGroupId { get; set; }
        public int DancerDancerId { get; set; }

        public virtual Dancer DancerDancer { get; set; }
        public virtual Group GroupGroup { get; set; }
    }
}
