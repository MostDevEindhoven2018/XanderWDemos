using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreMvcDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcDemo.Controllers
{
    public class StudentController : Controller
    {
        // EF uses Dependency Injection to get the db context
        public StudentController(MyDbContext _context)
        {
            ctx = _context;
        }

        MyDbContext ctx = null;

        public IActionResult Index()
        {
            // Check if the DB exists
            // If not, create it
            ctx.Database.EnsureCreated();

            // Use LINQ to define queries!
            var query = from s in ctx.Students
                        select s;

            // Alternative syntax using Lambda Expressions
            //var query2 = ctx.Students.Where(x => x.StudentID == 3);

            List<Student> results = query.ToList();

            return View(results);
        }

        // This one for showing the empty Create page (HttpGet)
        public IActionResult Create()
        {
            // Create a new page with a form for a new Student
            return View();
        }

        // This one is used after the user entered his name and pressed submit button
        [HttpPost]
        public IActionResult Create(Student newStudent)
        {
            if(ModelState.IsValid)
            {
                ctx.Students.Add(newStudent);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newStudent);
            }

        }

        public IActionResult Edit(int id)
        {
            var oldStudent = ctx.Students.Find(id);

            return View(oldStudent);
        }

        [HttpPost]
        public IActionResult Edit(Student newStudent)
        {
            if (ModelState.IsValid)
            {
                // Remember this one: (the one difference with Create)
                ctx.Entry(newStudent).State = EntityState.Modified;

                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newStudent);
            }

        }

        public IActionResult SeedDB()
        {
            var Xander1 = new Student
            {
                Firstname = "Xander",
                Lastname = "Houtman",
                Country = "Netherlands",
                PictureURL = "",
                DateOfBirth = new DateTime(1992, 1, 8)
            };

            var s2 = new Student
            {
                Firstname = "George",
                Lastname = "Vasileiadis",
                Country = "Greece",
                PictureURL = "",
                DateOfBirth = new DateTime(1992, 1, 8)
            };

            var s3 = new Student
            {
                Firstname = "Xander",
                Lastname = "Wemmers",
                Country = "Netherlands",
                PictureURL = "",
                DateOfBirth = new DateTime(1974, 2, 7)
            };

            var exam1 = new Exam()
            {
                Code = "70-483",
                Description = "C#"
            };

            var exam2 = new Exam()
            {
                Code = "70-486",
                Description = "ASP.NET MVC"
            };

            var result1 = new ExamResult
            {
                When = DateTime.Now,
                Score = 1000,
                Exam = exam1,
                Student = Xander1
            };

            var result2 = new ExamResult
            {
                When = DateTime.Now,
                Score = 999,
                Exam = exam2,
                Student = s2
            };

            var result3 = new ExamResult
            {
                When = DateTime.Now,
                Score = 1100,
                Exam = exam1,
                Student = s3
            };



            ctx.ExamResults.Add(result1);
            ctx.ExamResults.Add(result2);
            ctx.ExamResults.Add(result3);
            ctx.SaveChanges();

            return View();
        }


        public IActionResult AllResults()
        {

            var query = from r in ctx.ExamResults
                        select new AllResultsViewModel
                        {
                            Score = r.Score,
                            When = r.When,
                            Firstname = r.Student.Firstname,
                            Lastname = r.Student.Lastname,
                            Code = r.Exam.Code,
                            Description = r.Exam.Description
                        };

            return View(query.ToList());
        }

        public IActionResult AllResultsJson()
        {
            var query = from r in ctx.ExamResults
                        select new AllResultsViewModel
                        {
                            Score = r.Score,
                            When = r.When,
                            Firstname = r.Student.Firstname,
                            Lastname = r.Student.Lastname,
                            Code = r.Exam.Code,
                            Description = r.Exam.Description
                        };

            var results = query.ToList();

            return Json(results);
        }


    }
}
