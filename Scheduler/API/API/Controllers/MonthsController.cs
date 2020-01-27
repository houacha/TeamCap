using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class MonthsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Months
        public IQueryable<Month> GetMonths()
        {
            return db.Months;
        }

        // GET: api/Months/5
        [ResponseType(typeof(Month))]
        public IHttpActionResult GetMonth(int id)
        {
            Month month = db.Months.Find(id);
            if (month == null)
            {
                return NotFound();
            }

            return Ok(month);
        }

        // PUT: api/Months/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonth(int id, Month month)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != month.Id)
            {
                return BadRequest();
            }

            db.Entry(month).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Months
        [ResponseType(typeof(Month))]
        public IHttpActionResult PostMonth(Month month)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Months.Add(month);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = month.Id }, month);
        }

        // DELETE: api/Months/5
        [ResponseType(typeof(Month))]
        public IHttpActionResult DeleteMonth(int id)
        {
            Month month = db.Months.Find(id);
            if (month == null)
            {
                return NotFound();
            }

            db.Months.Remove(month);
            db.SaveChanges();

            return Ok(month);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonthExists(int id)
        {
            return db.Months.Count(e => e.Id == id) > 0;
        }
    }
}