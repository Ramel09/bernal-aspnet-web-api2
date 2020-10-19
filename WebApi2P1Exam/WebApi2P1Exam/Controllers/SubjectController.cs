using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2P1Exam.Models;

namespace WebApi2P1Exam.Controllers
{
    public class SubjectController : ApiController
    {
        SdWebApiDbContext _db = new SdWebApiDbContext();

		[HttpPost]
		public IHttpActionResult Create(Subject newsubject)
		{
			_db.Subjects.Add(newsubject);
			_db.SaveChanges();
			return Ok(newsubject);

		}
		[HttpGet]
		public IHttpActionResult GetAll(string keyword = "")
		{
			keyword = keyword.Trim();
			var subject = new List<Subject>();

			if (!string.IsNullOrEmpty(keyword))
			{
				subject = _db.Subjects
					.Where(x => x.Code.Contains(keyword) || x.DescriptiveTitle.Contains(keyword))
					.ToList();
			}
			else
				subject = _db.Subjects.ToList();

			return Ok(subject);
		}
		[HttpGet]
		public IHttpActionResult Get(int Id)
		{
			var subject = _db.Subjects.Find(Id);
			if (subject != null)
			{
				return Ok(subject);
			}
			else
				return BadRequest("Not Found");


		}
		[HttpPut]
		public IHttpActionResult Update(Subject updatesubject)
		{
			var subject = _db.Subjects.Find(updatesubject.Id);
			if (subject != null)
			{
				subject.Code = updatesubject.Code;
				subject.DescriptiveTitle = updatesubject.DescriptiveTitle;

				_db.Entry(subject).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();

				return Ok(subject);
			}
			else
				return BadRequest("Subject Not Found");

		}
		[HttpDelete]
		public IHttpActionResult Delete(int Id)
		{
			var subject = _db.Subjects.Find(Id);
			if (subject != null)
			{
				_db.Subjects.Remove(subject);
				_db.SaveChanges();

				return Ok("Subject Successfully Deleted!");
			}
			else
				return BadRequest("Not Found");

		}


	}
}
