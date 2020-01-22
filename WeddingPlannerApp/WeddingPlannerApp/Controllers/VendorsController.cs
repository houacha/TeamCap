using Microsoft.AspNet.Identity;
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
        private ApplicationDbContext db;
        HttpClient client;
        public VendorsController()
        {
            db = new ApplicationDbContext();
            client = new HttpClient();
        }

        //made a method just so i dont have to make one for every method
        //it's private because nothing else but this class needs it

        private VendorViewModel MakeModel(JToken item)
        {
            VendorViewModel vendor = new VendorViewModel()
            {
                Id = (int)item["Id"],
                VendorType = (string)item["VendorType"],
                Name = (string)item["Name"],
                Street = (string)item["Street"],
                City = (string)item["City"],
                Zip = (string)item["Zip"],
                State = (string)item["State"],
                Country = (string)item["Country"],
                PhotographerEmail = (string)item["PhotographerEmail"],
                PhotographerPhone = (string)item["PhotographerPhone"],
                DoesVideo = (bool?)item["DoesVideo"],
                DoesEditing = (bool?)item["DoesEditing"],
                LGBTQFriendly = (bool?)item["LGBTQFriendly"],
                DoesTravel = (bool?)item["DoesTravel"],
                CatererEmail = (string)item["CatererEmail"],
                CatererPhone = (string)item["CatererPhone"],
                FoodIndian = (bool?)item["FoodIndian"],
                FoodItalian = (bool?)item["FoodItalian"],
                FoodChinese = (bool?)item["FoodChinese"],
                FoodMediterranean = (bool?)item["FoodMediterranean"],
                FoodMexican = (bool?)item["FoodMexican"],
                FoodFrench = (bool?)item["FoodFrench"],
                FoodAmerican = (bool?)item["FoodAmerican"],
                FoodOther = (bool?)item["FoodOther"],
                ServesVegan = (bool?)item["ServesVegan"],
                FoodAllergyOptions = (bool?)item["FoodAllergyOptions"],
                PerGuestEstimateLow = (double?)item["PerGuestEstimateLow"],
                PerGuestEstimateHigh = (double?)item["PerGuestEstimateHigh"],
                CelebrantEmail = (string)item["CelebrantEmail"],
                CelebrantPhone = (string)item["CelebrantPhone"],
                Judaism = (bool?)item["Judaism"],
                Sikhism = (bool?)item["Sikhism"],
                Hinduism = (bool?)item["Hinduism"],
                Islamic = (bool?)item["Islamic"],
                NonDenominational = (bool?)item["NonDenominational"],
                Catholicism = (bool?)item["Catholicism"],
                Lutheranism = (bool?)item["Lutheranism"],
                Buddhism = (bool?)item["Buddhism"],
                ReligionOther = (bool?)item["ReligionOther"],
                DJEmail = (string)item["DJEmail"],
                DJPhone = (string)item["DJPhone"],
                GenrePop = (bool?)item["GenrePop"],
                GenreRB = (bool?)item["GenreRB"],
                GenreRap = (bool?)item["GenreRap"],
                GenreRock = (bool?)item["GenreRock"],
                GenreCountry = (bool?)item["GenreCountry"],
                GenreDance = (bool?)item["GenreDance"],
                GenreTechno = (bool?)item["GenreTechno"],
                GenreMetal = (bool?)item["GenreMetal"],
                GenreInternational = (bool?)item["GenreInternational"],
                GenreOther = (bool?)item["GenreOther"],
                VenueEmail = (string)item["VenueEmail"],
                VenuePhone = (string)item["VenuePhone"],
                KidFriendly = (bool?)item["KidFriendly"],
                PetFriendly = (bool?)item["PetFriendly"],
                HandicapAccessible = (bool?)item["HandicapAccessible"],
                ServesCohabitants = (bool?)item["ServesCohabitants"],
                Ceremony = (bool?)item["Ceremony"],
                Reception = (bool?)item["Reception"],
                ProvidesLodging = (bool?)item["ProvidesLodging"],
                AllowsDecor = (bool?)item["AllowsDecor"],
                ThirdPartyCelebrant = (bool?)item["ThirdPartyCelebrant"],
                ThirdPartyCatering = (bool?)item["ThirdPartyCatering"],
                ThirdPartyDJ = (bool?)item["ThirdPartyDJ"],
                Caterers = (bool?)item["Caterers"]
            };
            return vendor;
        }

        // GET: Vendors
        public ActionResult Index(string type)
        {
            type = "Venues";
            List<VendorViewModel> venueList = new List<VendorViewModel>();
            client.BaseAddress = new Uri("https://localhost:44317/api/");
            var response = client.GetAsync(type);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JArray venueArray = JArray.Parse(service);
                foreach (var item in venueArray)
                {
                    var vendor = MakeModel(item);
                    venueList.Add(vendor);
                }
            }
            ViewBag.VenderType = type;
            return View(venueList);
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id, string type)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorViewModel vendor = new VendorViewModel();
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.GetAsync(type);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JObject jObject = JObject.Parse(service);
                vendor = MakeModel(jObject);
            }
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
        public ActionResult Create([Bind(Include = "Id,VendorId")] VendorViewModel service)
        {
            if (ModelState.IsValid)
            {
                Vendor vendor = new Vendor();
                string json = JsonConvert.SerializeObject(service);
                var response = client.PostAsync(service.VendorType + "s", new StringContent(json));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    vendor.ApplicationId = User.Identity.GetUserId();
                    client.BaseAddress = new Uri("https://localhost:44317/api/");
                    response = client.GetAsync(service.VendorType + "s");
                    response.Wait();
                    result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var read = result.Content.ReadAsStringAsync();
                        read.Wait();
                        var readResult = read.Result;
                        JArray jObject = JArray.Parse(readResult);
                        var lastObject = jObject.Last();
                        vendor.VendorId = (int?)lastObject["VendorId"];
                        vendor.VendorType = service.VendorType;
                        db.Vendors.Add(vendor);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("LogOut","Account");
            }
            return View(service);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id, string type)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorViewModel vendor = new VendorViewModel();
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.GetAsync(type);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JObject jObject = JObject.Parse(service);
                vendor = MakeModel(jObject);
            }
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
        public ActionResult Edit([Bind(Include = "Id,VendorId")] VendorViewModel vendor)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(vendor);
                client.BaseAddress = new Uri("https://localhost:44317/api/" + vendor.Id);
                var response = client.PutAsync(vendor.VendorType + "s", new StringContent(json));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var userId = User.Identity.GetUserId();
                    var currentUser = db.Vendors.Where(v => v.ApplicationId == userId).Select(v => v).SingleOrDefault();
                    currentUser.VendorId = vendor.Id;
                    currentUser.VendorType = vendor.VendorType;                   
                    db.SaveChanges();
                }
                return RedirectToAction("Details", new { id = vendor.Id, type = vendor.VendorType + "s"});
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id, string type)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorViewModel vendor = new VendorViewModel();
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.GetAsync(type);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JObject jObject = JObject.Parse(service);
                vendor = MakeModel(jObject);
            }
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string type)
        {
            client.BaseAddress = new Uri("https://localhost:44317/api/" + id);
            var response = client.DeleteAsync(type);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var userId = User.Identity.GetUserId();
                var currentUser = db.Users.Where(u => u.Id == userId).Select(u => u).SingleOrDefault();
                Vendor vendor = db.Vendors.Where(v => v.VendorId == id).Select(v => v).SingleOrDefault();
                db.Users.Remove(currentUser);
                db.Vendors.Remove(vendor);
                db.SaveChanges();
            }
            return RedirectToAction("LogOut","Account");
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
