using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WeddingPlannerApp.Models;

namespace WeddingPlannerApp.Controllers
{
    public class VendorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendors
        public ActionResult Index()
        {
            List<VendorViewModel> venueList = new List<VendorViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44317/api/");
                var response = client.GetAsync("Venues");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsStringAsync();
                    read.Wait();
                    var venues = read.Result;
                    JArray thing = JArray.Parse(venues);
                    foreach (var item in thing)
                    {
                        VendorViewModel butter = new VendorViewModel()
                        {
                            VendorId = (int)item["VendorId"],
                            VendorType = (string)item["VendorType"],
                            Name = (string)item["Name"],
                            Street = (string)item["Street"],
                            City = (string)item["City"],
                            Zip = (string)item["Zip"],
                            State = (string)item["State"],
                            Country = (string)item["Country"],
                            VenueEmail = (string)item["VenueEmail"],
                            VenuePhone = (string)item["VenuePhone"],
                            LGBTQFriendly = (bool)item["LGBTQFriendly"],
                            KidFriendly = (bool)item["KidFriendly"],
                            PetFriendly = (bool)item["PetFriendly"],
                            HandicapAccessible = (bool)item["HandicapAccessible"],
                            Judaism = (bool)item["Judaism"],
                            Sikhism = (bool)item["Sikhism"],
                            Hinduism = (bool)item["Hinduism"],
                            Islamic = (bool)item["Islamic"],
                            NonDenominational = (bool)item["NonDenominational"],
                            Catholicism = (bool)item["Catholicism"],
                            Lutheranism = (bool)item["Lutheranism"],
                            Buddhism = (bool)item["Buddhism"],
                            ReligionOther = (bool)item["ReligionOther"],
                            ServesCohabitants = (bool)item["ServesCohabitants"],
                            Ceremony = (bool)item["Ceremony"],
                            Reception = (bool)item["Reception"],
                            ProvidesLodging = (bool)item["ProvidesLodging"],
                            AllowsDecor = (bool)item["AllowsDecor"],
                            ThirdPartyCelebrant = (bool)item["ThirdPartyCelebrant"],
                            ThirdPartyCatering = (bool)item["ThirdPartyCatering"],
                            ThirdPartyDJ = (bool)item["ThirdPartyDJ"],
                            Caterers = (bool)item["Caterers"]
                        };
                        venueList.Add(butter);
                    }
                }
            }

            return View(venueList);
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VendorId")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VendorId")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
