using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2P1Exam.Models;

namespace WebApi2P1Exam.Controllers
{
    public class FacultyController : ApiController
    {
        SdWebApiDbContext _db = new SdWebApiDbContext();

		[HttpPost]
		public IHttpActionResult Create(Faculty newfaculty)
		{
			_db.Facultys.Add(newfaculty);
			_db.SaveChanges();
			return Ok(newfaculty);

		}
		[HttpGet]
		public IHttpActionResult GetAll(string keyword = "")
		{
			keyword = keyword.Trim();

			var faculty = new List<Faculty>();
			if (!string.IsNullOrEmpty(keyword))
			{
				faculty = _db.Facultys
					.Where(x => x.FirstName.Contains(keyword) || x.LastName.Contains(keyword))
					.ToList();

			}
			else
				faculty = _db.Facultys.ToList();

			return Ok(faculty);
		}
		[HttpGet]
		public IHttpActionResult Get(int Id)
		{
			var faculty = _db.Facultys.Find(Id);
			if (faculty != null)
			{
				return Ok(faculty);
			}
			else
				return BadRequest("Not found");
		}
		[HttpPut]
		public IHttpActionResult Update(Faculty updatefacullty)
		{
			var faculty = _db.Facultys.Find(updatefacullty);
			if (faculty != null)
			{

				faculty.FirstName = updatefacullty.FirstName;
				faculty.LastName = updatefacullty.LastName;
				faculty.Gender = updatefacullty.Gender;
				faculty.CivilStatus = updatefacullty.CivilStatus;
				faculty.SSSNumber = updatefacullty.SSSNumber;
				faculty.SuperVisor = updatefacullty.SuperVisor;
				

			
				_db.Entry(faculty).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();

				return Ok(faculty);

			}
			else
				return BadRequest("Not Found....");
		}
		[HttpDelete]
		public IHttpActionResult Delete(int Id)
		{
			var faculty = _db.Facultys.Find(Id);
			if (faculty != null)
			{
				_db.Facultys.Remove(faculty);
				_db.SaveChanges();
				return Ok("Faculty Successfully Deleted!");


			}
			else
				return BadRequest("Faculty Not Found");

		}

	}
}
