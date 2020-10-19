using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2P1Exam.Models
{
    public class Student: Person
    {
        public string SchoolLastAttended { get; set; }
        public int CourseId { get; set; }

    }
}