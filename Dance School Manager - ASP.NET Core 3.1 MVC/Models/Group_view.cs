using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Parent view model 
namespace DanceSchool_10._05_ASP.NET_MVC.Models
{
    public class Group_view
    {  public Dancer Dancer { get; set; }
        public Group Group{ get; set; }
        public List <Dancer> Dancerl { get; set; }
        public List< Group>  Groupl { get; set; }
    }
       
}
