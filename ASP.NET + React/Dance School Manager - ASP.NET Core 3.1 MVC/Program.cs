using DanceSchool_10._05_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Configuration; 
using System.Data.SqlClient;
using SQLitePCL;
using System.Collections.Generic;

namespace DanceSchool_10._05_ASP.NET_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            mydbContext _context = new mydbContext();
           
            

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //prvides an default configuration for the app
                                            //it adds IConfigurati=====on as a source 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //adds new instance of the startupclass!!
    }
}
