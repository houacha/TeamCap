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
    public class ServiceContractsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ServiceContracts
        public IQueryable<ServiceContract> GetServiceContracts()
        {
            return db.ServiceContracts;
        }

        // GET: api/ServiceContracts/5
        [ResponseType(typeof(ServiceContract))]
        public IHttpActionResult GetServiceContract(int id)
        {
            ServiceContract serviceContract = db.ServiceContracts.Find(id);
            if (serviceContract == null)
            {
                return NotFound();
            }

            return Ok(serviceContract);
        }

        // PUT: api/ServiceContracts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceContract(int id, ServiceContract serviceContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceContract.Id)
            {
                return BadRequest();
            }

            db.Entry(serviceContract).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceContractExists(id))
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

        // POST: api/ServiceContracts
        [ResponseType(typeof(ServiceContract))]
        public IHttpActionResult PostServiceContract(ServiceContract serviceContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceContracts.Add(serviceContract);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceContract.Id }, serviceContract);
        }

        // DELETE: api/ServiceContracts/5
        [ResponseType(typeof(ServiceContract))]
        public IHttpActionResult DeleteServiceContract(int id)
        {
            ServiceContract serviceContract = db.ServiceContracts.Find(id);
            if (serviceContract == null)
            {
                return NotFound();
            }

            db.ServiceContracts.Remove(serviceContract);
            db.SaveChanges();

            return Ok(serviceContract);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceContractExists(int id)
        {
            return db.ServiceContracts.Count(e => e.Id == id) > 0;
        }
    }
}