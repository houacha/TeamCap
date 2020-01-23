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
    public class WeddingPackagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WeddingPackages
        public IQueryable<WeddingPackage> GetWeddingPackages()
        {
            return db.WeddingPackages;
        }

        // GET: api/WeddingPackages/5
        [ResponseType(typeof(WeddingPackage))]
        public IHttpActionResult GetWeddingPackage(int id)
        {
            WeddingPackage weddingPackage = db.WeddingPackages.Find(id);
            if (weddingPackage == null)
            {
                return NotFound();
            }

            return Ok(weddingPackage);
        }

        // PUT: api/WeddingPackages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWeddingPackage(int id, WeddingPackage weddingPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weddingPackage.Id)
            {
                return BadRequest();
            }

            db.Entry(weddingPackage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeddingPackageExists(id))
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

        // POST: api/WeddingPackages
        [ResponseType(typeof(WeddingPackage))]
        public IHttpActionResult PostWeddingPackage(WeddingPackage weddingPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WeddingPackages.Add(weddingPackage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = weddingPackage.Id }, weddingPackage);
        }

        // DELETE: api/WeddingPackages/5
        [ResponseType(typeof(WeddingPackage))]
        public IHttpActionResult DeleteWeddingPackage(int id)
        {
            WeddingPackage weddingPackage = db.WeddingPackages.Find(id);
            if (weddingPackage == null)
            {
                return NotFound();
            }

            db.WeddingPackages.Remove(weddingPackage);
            db.SaveChanges();

            return Ok(weddingPackage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WeddingPackageExists(int id)
        {
            return db.WeddingPackages.Count(e => e.Id == id) > 0;
        }
    }
}