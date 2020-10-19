using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi2P1Exam.Models
{
    public class SdWebApiDbContext: DbContext
    {
        public SdWebApiDbContext() : base("StudentInfo") // name_of_dbconnection_string
        {
        }

        // Map model classes to database tables
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
      
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<Subject> Subjects { get; set; }





    }
}