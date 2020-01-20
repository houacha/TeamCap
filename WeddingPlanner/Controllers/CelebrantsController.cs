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
    public class CelebrantsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Celebrants
        public IQueryable<Celebrant> GetCelebrants()
        {
            return db.Celebrants;
        }

        // GET: api/Celebrants/5
        [ResponseType(typeof(Celebrant))]
        public IHttpActionResult GetCelebrant(int id)
        {
            Celebrant celebrant = db.Celebrants.Find(id);
            if (celebrant == null)
            {
                return NotFound();
            }

            return Ok(celebrant);
        }

        // PUT: api/Celebrants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCelebrant(int id, Celebrant celebrant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != celebrant.Id)
            {
                return BadRequest();
            }

            db.Entry(celebrant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelebrantExists(id))
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

        // POST: api/Celebrants
        [ResponseType(typeof(Celebrant))]
        public IHttpActionResult PostCelebrant(Celebrant celebrant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Celebrants.Add(celebrant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = celebrant.Id }, celebrant);
        }

        // DELETE: api/Celebrants/5
        [ResponseType(typeof(Celebrant))]
        public IHttpActionResult DeleteCelebrant(int id)
        {
            Celebrant celebrant = db.Celebrants.Find(id);
            if (celebrant == null)
            {
                return NotFound();
            }

            db.Celebrants.Remove(celebrant);
            db.SaveChanges();

            return Ok(celebrant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CelebrantExists(int id)
        {
            return db.Celebrants.Count(e => e.Id == id) > 0;
        }
    }
}