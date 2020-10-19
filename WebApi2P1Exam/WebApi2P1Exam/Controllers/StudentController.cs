using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2P1Exam.Models;

namespace WebApi2P1Exam.Controllers
{
    public class StudentController : ApiController
    {
        SdWebApiDbContext _db = new SdWebApiDbContext();

        [HttpGet]
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var students = new List<Student>();

            if (!string.IsNullOrEmpty(keyword))
            {
                students = _db.Students
                    .Where(x => x.LastName.Contains(keyword) || x.FirstName.Contains(keyword))
                    .ToList();
            }
            else
                students = _db.Students.ToList();

            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            var students = _db.Students.Find(Id);
            if (students != null)
                return Ok(students);
            else
                return BadRequest("Student not found");
        }

        [HttpPost]
        public IHttpActionResult Create(Student newStudent)
        {
            _db.Students.Add(newStudent);
            _db.SaveChanges();
            return Ok(newStudent);
        }


        [HttpPut]
        public IHttpActionResult Update(Student updatedStudent)
        {
            var students = _db.Students.Find(updatedStudent.Id);
            if (students != null)
            {
                students.FirstName = updatedStudent.FirstName;
                students.LastName = updatedStudent.LastName;
                students.Gender = updatedStudent.Gender;
                students.CivilStatus = updatedStudent.CivilStatus;
                students.SchoolLastAttended = updatedStudent.SchoolLastAttended;
                students.CourseId = updatedStudent.CourseId;
            

                _db.Entry(students).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(students);
            }
            else
                return BadRequest("Student not found");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var students = _db.Students.Find(Id);
            if (students != null)
            {
                _db.Students.Remove(students);
                _db.SaveChanges();
                return Ok("Student successfully deleted");
            }
            else
                return BadRequest("Student not found");
        }


    }
}
