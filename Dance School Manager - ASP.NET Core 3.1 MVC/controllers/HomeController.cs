using DanceSchool_10._05_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;


//main logic of the application
//it matches with the 'home' folder in the views 
//if we want to add new conncoler we have to create new folder in views!
namespace DanceSchool_10._05_ASP.NET_MVC.Controllers
{


        public class HomeController : Controller
        {

        mydbContext _context = new mydbContext();

    

        private readonly ILogger<HomeController> _logger;

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }
        //methods are called acctions 
        public async Task<IActionResult> Index()
            {
            
             HashSet<DayOfWeek>set =  new HashSet<DayOfWeek>();
             foreach (var item in _context.Classes)
              {
                set.Add(item.Weekday.DayOfWeek);
                }
            List<List<Class>> listoflist = new List<List<Class>>();
          
            foreach (var day in set)
            {
               var classelem= (from s in _context.Classes.ToList()
                                  where s.Weekday.DayOfWeek == day
                                  select s).ToList();

                listoflist.Add(classelem); 
                
            }

            var tup = Tuple.Create(set, listoflist);
            return View(tup);
        }
   
        
        public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
