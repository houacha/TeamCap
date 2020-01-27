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
    public class TimesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Times
        public IQueryable<Time> GetTimes()
        {
            return db.Times;
        }

        // GET: api/Times/5
        [ResponseType(typeof(Time))]
        public IHttpActionResult GetTime(int id)
        {
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return NotFound();
            }

            return Ok(time);
        }

        // PUT: api/Times/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTime(int id, Time time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != time.Id)
            {
                return BadRequest();
            }

            db.Entry(time).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeExists(id))
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

        // POST: api/Times
        [ResponseType(typeof(Time))]
        public IHttpActionResult PostTime(Time time)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Times.Add(time);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = time.Id }, time);
        }

        // DELETE: api/Times/5
        [ResponseType(typeof(Time))]
        public IHttpActionResult DeleteTime(int id)
        {
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return NotFound();
            }

            db.Times.Remove(time);
            db.SaveChanges();

            return Ok(time);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeExists(int id)
        {
            return db.Times.Count(e => e.Id == id) > 0;
        }
    }
}