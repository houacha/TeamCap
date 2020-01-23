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
    public class VendorPackagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/VendorPackages
        public IQueryable<VendorPackage> GetVendorPackages()
        {
            return db.VendorPackages;
        }

        // GET: api/VendorPackages/5
        [ResponseType(typeof(VendorPackage))]
        public IHttpActionResult GetVendorPackage(int id)
        {
            VendorPackage vendorPackage = db.VendorPackages.Find(id);
            if (vendorPackage == null)
            {
                return NotFound();
            }

            return Ok(vendorPackage);
        }

        // PUT: api/VendorPackages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendorPackage(int id, VendorPackage vendorPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendorPackage.Id)
            {
                return BadRequest();
            }

            db.Entry(vendorPackage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorPackageExists(id))
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

        // POST: api/VendorPackages
        [ResponseType(typeof(VendorPackage))]
        public IHttpActionResult PostVendorPackage(VendorPackage vendorPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendorPackages.Add(vendorPackage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vendorPackage.Id }, vendorPackage);
        }

        // DELETE: api/VendorPackages/5
        [ResponseType(typeof(VendorPackage))]
        public IHttpActionResult DeleteVendorPackage(int id)
        {
            VendorPackage vendorPackage = db.VendorPackages.Find(id);
            if (vendorPackage == null)
            {
                return NotFound();
            }

            db.VendorPackages.Remove(vendorPackage);
            db.SaveChanges();

            return Ok(vendorPackage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendorPackageExists(int id)
        {
            return db.VendorPackages.Count(e => e.Id == id) > 0;
        }
    }
}