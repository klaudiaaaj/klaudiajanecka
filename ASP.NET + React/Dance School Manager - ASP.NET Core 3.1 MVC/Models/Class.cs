using System;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public string DancestyleId { get; set; }
        public int GroupId { get; set; }
        public int HourId { get; set; }
        public int? ClassroomId { get; set; }
        public DateTime Weekday { get; set; }

        public virtual Group Group { get; set; }
        public virtual Hour Hour { get; set; }
    }
}
