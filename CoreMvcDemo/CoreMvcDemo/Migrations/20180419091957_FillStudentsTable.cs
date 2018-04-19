using CoreMvcDemo.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreMvcDemo.Migrations
{
    public partial class FillStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var st = new Student
            {
                Firstname = "Xander",
                Lastname = "Wemmers"
            };


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
