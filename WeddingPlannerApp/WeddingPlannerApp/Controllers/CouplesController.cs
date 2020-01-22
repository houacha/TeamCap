using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WeddingPlannerApp.Models;
using Microsoft.AspNet.Identity;

namespace WeddingPlannerApp.Controllers
{
    public class CouplesController : Controller
    {
        private ApplicationDbContext db;
        private HttpClient client;
        public CouplesController()
        {
            db = new ApplicationDbContext();
            client = new HttpClient();
        }
        private CoupleViewModel MakeModel(JToken item)
        {
            CoupleViewModel couple = new CoupleViewModel()
            {
                Partner1FirstName = (string)item["Partner1FirstName"],
                Partner1LastName = (string)item["Partner1LastName"],
                Partner2FirstName = (string)item["Partner2FirstName"],
                Partner2LastName=(string)item["Partner2LastName"],
                CoupleStreetAddress=(string)item["CoupleStreetAddress"],
                City=(string)item["City"],
                Zipcode=(int)item["Zipcode"],
                WeddingBudget=(double)item["WeddingBudget"],
                EstimatedTotal=(double)item["EstimatedTotal"],
                CoupleEmail=(string)item["CoupleEmail"],
                CouplePhone=(string)item["CouplePhone"]
            };
            return couple;
        }

        // GET: Couples
        public ActionResult Index()
        {
            return View(db.Couples.ToList());
        }

        // GET: Couples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoupleViewModel couple = new CoupleViewModel();
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.GetAsync("Couples/"+id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JObject jObject = JObject.Parse(service);
                couple = MakeModel(jObject);
            }
            if (couple == null)
            {
                return HttpNotFound();
            }
            return View(couple);
        }

        // GET: Couples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Couples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CoupleId")] CoupleViewModel service)
        {
            if (ModelState.IsValid)
            {
                Couple couple = new Couple();
                string json = JsonConvert.SerializeObject(service);
                client.BaseAddress = new Uri("https://localhost:44317/api/");
                var response = client.PostAsync("Couples", new StringContent(json));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    couple.ApplicationId = User.Identity.GetUserId();
                    client.BaseAddress = new Uri("https://localhost:44317/api/");
                    response = client.GetAsync("Couples");
                    response.Wait();
                    result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var read = result.Content.ReadAsStringAsync();
                        read.Wait();
                        var readResult = read.Result;
                        JArray jObject = JArray.Parse(readResult);
                        var lastObject = jObject.Last();
                        couple.CoupleId = (int)lastObject["CoupleId"];
                        //couple.VendorType = service.VendorType;
                        db.Couples.Add(couple);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("LogOut", "Account");
            }
            return View(service);
        }

        // GET: Couples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoupleViewModel couple = new CoupleViewModel();
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.GetAsync("Couples/"+id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JObject jObject = JObject.Parse(service);
                couple = MakeModel(jObject);
            }
            if (couple == null)
            {
                return HttpNotFound();
            }
            return View(couple);
        }

        // POST: Couples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CoupleId")] Couple couple)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(couple);
                client.BaseAddress = new Uri("https://localhost:44317/api/" + couple.Id);//possibly add "/Couple/+couple.Id
                var response = client.PutAsync("Couples", new StringContent(json));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var userId = User.Identity.GetUserId();
                    var currentUser = db.Couples.Where(v => v.ApplicationId == userId).Select(v => v).SingleOrDefault();
                    currentUser.CoupleId = couple.Id;
                    //currentUser.VendorType = vendor.VendorType;
                    db.SaveChanges();
                }
                return RedirectToAction("Details", new { id = couple.Id });
            }
            return View(couple);
        }

        // GET: Couples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoupleViewModel couple = new CoupleViewModel();
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.GetAsync("Couples/"+id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JObject jObject = JObject.Parse(service);
                couple = MakeModel(jObject);
            }
            if (couple == null)
            {
                return HttpNotFound();
            }
            return View(couple);
        }

        // POST: Couples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.DeleteAsync("Couples/"+id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var userId = User.Identity.GetUserId();
                var currentUser = db.Users.Where(u => u.Id == userId).Select(u => u).SingleOrDefault();
                Couple couple = db.Couples.Where(v => v.CoupleId == id).Select(v => v).SingleOrDefault();
                db.Users.Remove(currentUser);
                db.Couples.Remove(couple);
                db.SaveChanges();
            }
            return RedirectToAction("LogOut", "Account");
        }
    }
}
