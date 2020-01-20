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
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class CouplesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Couples
        public IQueryable<Couple> GetCouples()
        {
            return db.Couples;
        }

        // GET: api/Couples/5
        [ResponseType(typeof(Couple))]
        public IHttpActionResult GetCouple(int id)
        {
            Couple couple = db.Couples.Find(id);
            if (couple == null)
            {
                return NotFound();
            }

            return Ok(couple);
        }

        // PUT: api/Couples/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCouple(int id, Couple couple)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != couple.Id)
            {
                return BadRequest();
            }

            db.Entry(couple).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoupleExists(id))
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

        // POST: api/Couples
        [ResponseType(typeof(Couple))]
        public IHttpActionResult PostCouple(Couple couple)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Couples.Add(couple);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = couple.Id }, couple);
        }

        // DELETE: api/Couples/5
        [ResponseType(typeof(Couple))]
        public IHttpActionResult DeleteCouple(int id)
        {
            Couple couple = db.Couples.Find(id);
            if (couple == null)
            {
                return NotFound();
            }

            db.Couples.Remove(couple);
            db.SaveChanges();

            return Ok(couple);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoupleExists(int id)
        {
            return db.Couples.Count(e => e.Id == id) > 0;
        }
    }
}