using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMvcDemo.Models;

namespace CoreMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
    }
}
