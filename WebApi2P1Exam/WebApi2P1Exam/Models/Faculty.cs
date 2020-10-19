using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2P1Exam.Models
{
    public class Faculty:Person
    {
        public string SSSNumber { get; set; }
        public string SuperVisor { get; set; }

    }
}