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
    public class CaterersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Caterers
        public IQueryable<Caterer> GetCaterers()
        {
            return db.Caterers;
        }

        // GET: api/Caterers/5
        [ResponseType(typeof(Caterer))]
        public IHttpActionResult GetCaterer(int id)
        {
            Caterer caterer = db.Caterers.Find(id);
            if (caterer == null)
            {
                return NotFound();
            }

            return Ok(caterer);
        }

        // PUT: api/Caterers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCaterer(int id, Caterer caterer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caterer.Id)
            {
                return BadRequest();
            }

            db.Entry(caterer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatererExists(id))
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

        // POST: api/Caterers
        [ResponseType(typeof(Caterer))]
        public IHttpActionResult PostCaterer(Caterer caterer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Caterers.Add(caterer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caterer.Id }, caterer);
        }

        // DELETE: api/Caterers/5
        [ResponseType(typeof(Caterer))]
        public IHttpActionResult DeleteCaterer(int id)
        {
            Caterer caterer = db.Caterers.Find(id);
            if (caterer == null)
            {
                return NotFound();
            }

            db.Caterers.Remove(caterer);
            db.SaveChanges();

            return Ok(caterer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatererExists(int id)
        {
            return db.Caterers.Count(e => e.Id == id) > 0;
        }
    }
}