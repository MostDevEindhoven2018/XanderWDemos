using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMvcDemo.Models;
using Microsoft.AspNetCore.Http;

using System.Web;
using DinkToPdf;
using Microsoft.AspNetCore.Authorization;

namespace CoreMvcDemo.Controllers
{
    //[Authorize(Roles = "Tester")]
    public class HomeController : Controller
    {
        // EF uses Dependency Injection to get the db context
        public HomeController(MyDbContext _context)
        {
            ctx = _context;
        }

        MyDbContext ctx = null;

        public IActionResult Index()
        {
            ViewBag.TheDay = HttpContext.Session.GetInt32("TheChosenDay");
            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var st = new Student();
            st.Firstname = "Xander";
            st.Lastname = "Wemmers";
            st.DateOfBirth = new DateTime(1974, 2, 7);
            st.PictureURL = "http://www.xanderwemmers.nl/picture.jpg";

            // or use a local picture and place it in the folder
            // wwwroot/images
            st.PictureURL = "/Images/Sheep.jpg";

            return View(st);
        }

        public IActionResult AllStudents()
        {
            var list = new List<string>();
            list.Add("George");
            list.Add("Mathijs");
            list.Add("Paulina");
            list.Add("Kirsten");
            list.Add("Xander");
            list.Add("Roy");
            list.Add("Vishnu");
            list.Add("Kiran");
            list.Add("Irene Erica");
            list.Add("Xiao");
            list.Add("Liwei");
            list.Add("Xander");

            return View(list);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult CssDemo()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult JavascriptDemo()
        {
            return View();
        }

        public IActionResult TablesDemo()
        {
            return View();
        }


        public IActionResult FormDemo()
        {
            ViewBag.Names = new[] { "Xander", "Gerard", "Aeneas" };

            return View();
        }

        [HttpPost]
        //public IActionResult FormDemo(int firstNumber, int secondNumber, int year, int month, int day, int hours, int minutes)        //public IActionResult FormDemo(int firstNumber, int secondNumber, int year, int month, int day, int hours, int minutes)        //public IActionResult FormDemo(int firstNumber, int secondNumber, int year, int month, int day, int hours, int minutes)
        public IActionResult FormDemo(IFormCollection col, int secondNumber, int GuestID, int day)
        {
            //var mydate = new DateTime(year, month, day, hours, minutes, 0);

            //int firstNumber = int.Parse(col["firstNumber"]);

            // user data can be stored in the session
            HttpContext.Session.SetInt32("TheChosenDay", day);

            return View();
        }

        public IActionResult PdfTest()
        {
            var converter = new BasicConverter(new PdfTools());

            var v = Menu() as ViewResult;

            
            

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = @"<h1>A test PDF</h1>Lorem ipsum dolor sit amet, consectetur adipiscing elit. In consectetur mauris eget ultrices  iaculis. Ut                               odio viverra, molestie lectus nec, venenatis turpis.",
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };

            byte[] pdf = converter.Convert(doc);

            return File(pdf, "application/pdf");
        }

        public IActionResult MultipleForms()
        {
            var list = this.ctx.Students.ToList();

            return View(list);
        }

        [HttpPost]
        public IActionResult MultipleForms(int id, string Firstname, string Lastname)
        {
            var list = this.ctx.Students.ToList();

            return View(list);
        }
    }
}
