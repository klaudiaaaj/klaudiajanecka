using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanceSchool_10._05_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DanceSchool_10._05_ASP.NET_MVC.controllers
{
    public class OffertController : Controller
    {
        public readonly mydbContext _context; 
        public delegate T del<T>(T x);

        public static class GenericCalculations
        {
            static int one_price = 40;

            public static double CalcPriceId(double discount)
            {
                return one_price - one_price *(0.01* discount); 
            }
            public static int CalcDIscount(int id)
            {
                return 5 * (id-1); 
            }
            public static double calcGeneralPrice (double price2add, double price) 
            {
                return price + price2add; 
            }
        }


        public ActionResult Index()
        {

            return View(); 
        }

        // GET: HomeController1/Details/5

        public IActionResult DisplayOffert(int amount)
        {
            double price = 40;
            del<int> CalcDisc = new del<int>(GenericCalculations.CalcDIscount);
            del<double> CalcPri = new del<double>(GenericCalculations.CalcPriceId);

            SortedList <int,double> sorlis = new SortedList<int, double>();
            for (int i = 1; i <= amount; i++)
            {

                if (i != 1)
                {
                    sorlis.Add(CalcDisc(i), CalcPri(CalcDisc(i)));
                    price = GenericCalculations.calcGeneralPrice(price, CalcPri(CalcDisc(i)));
                }
                else
                { 
                    sorlis.Add(0, 40);
                }
            }
            var tup = Tuple.Create(sorlis, price);
            return View(tup); 
        }
     
     
        public ActionResult Details(int id)
        {
            return Content("NIC"); 
          
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
  

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Contact([Bind("Name, Surname, Email, Phonenr")] RequestModel rq)
        {

            if ( ModelState.IsValid)
            {
                ViewBag.message = "Success, you data is correct. We will contact you soon"; 
                return View(rq); 

            }
            return View(rq);
    
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View(); 
        }
      

            // POST: HomeController1/Delete/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
