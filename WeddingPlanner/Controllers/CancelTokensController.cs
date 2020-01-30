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
    public class CancelTokensController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CancelTokens
        public IQueryable<CancelToken> GetCancelTokens()
        {
            return db.CancelTokens;
        }

        // GET: api/CancelTokens/5
        [ResponseType(typeof(CancelToken))]
        public IHttpActionResult GetCancelToken(int id)
        {
            CancelToken cancelToken = db.CancelTokens.Find(id);
            if (cancelToken == null)
            {
                return NotFound();
            }

            return Ok(cancelToken);
        }

        // PUT: api/CancelTokens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCancelToken(int id, CancelToken cancelToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cancelToken.Id)
            {
                return BadRequest();
            }

            db.Entry(cancelToken).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancelTokenExists(id))
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

        // POST: api/CancelTokens
        [ResponseType(typeof(CancelToken))]
        public IHttpActionResult PostCancelToken(CancelToken cancelToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CancelTokens.Add(cancelToken);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cancelToken.Id }, cancelToken);
        }

        // DELETE: api/CancelTokens/5
        [ResponseType(typeof(CancelToken))]
        public IHttpActionResult DeleteCancelToken(int id)
        {
            CancelToken cancelToken = db.CancelTokens.Find(id);
            if (cancelToken == null)
            {
                return NotFound();
            }

            db.CancelTokens.Remove(cancelToken);
            db.SaveChanges();

            return Ok(cancelToken);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CancelTokenExists(int id)
        {
            return db.CancelTokens.Count(e => e.Id == id) > 0;
        }
    }
}