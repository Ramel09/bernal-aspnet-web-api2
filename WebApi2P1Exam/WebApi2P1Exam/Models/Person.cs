using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2P1Exam.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }

    }
}