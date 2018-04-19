using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace CoreMvcDemo.Models
{
    public class MyDbContext : DbContext
    {
        // This defines the database options
        public MyDbContext(DbContextOptions<MyDbContext> options) 
            : base(options)
        {

        }

        public MyDbContext()
        {

        }


        // This defines the DB table Students (based on class Student)
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
    }
}
