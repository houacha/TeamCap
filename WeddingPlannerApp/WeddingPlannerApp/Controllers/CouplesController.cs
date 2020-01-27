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
using System.Text;
using System.Reflection;

namespace WeddingPlannerApp.Controllers
{
    public class CouplesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private HttpClient client;
        public CouplesController()
        {
            db = new ApplicationDbContext();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44317/api/");
        }

        public WeddingPackageViewModel PackageModel(JToken token)
        {
            WeddingPackageViewModel package = new WeddingPackageViewModel()
            {
                Id = (int)token["Id"],
                AllowsDecor = (bool?)token["AllowsDecor"],
                ThirdPartyCatering = (bool?)token["ThirdPartyCatering"],
                ThirdPartyCelebrant = (bool?)token["ThirdPartyCelebrant"],
                ThirdPartyDJ = (bool?)token["ThirdPartyDJ"],
                LGBTQFriendly = (bool?)token["LGBTQFriendly"],
                ServesCohabitants = (bool?)token["ServesCohabitants"],
                KidFriendly = (bool?)token["KidFriendly"],
                PetFriendly = (bool?)token["PetFriendly"],
                WheelchairAccessible = (bool?)token["WheelchairAccessible"],
                FoodAllergyOptions = (bool?)token["FoodAllergyOptions"],
                Vegan = (bool?)token["Vegan"],
                FoodIndian = (bool?)token["FoodIndian"],
                FoodItalian = (bool?)token["FoodItalian"],
                FoodChinese = (bool?)token["FoodChinese"],
                FoodMediterranean = (bool?)token["FoodMediterranean"],
                FoodMexican = (bool?)token["FoodMexican"],
                FoodFrench = (bool?)token["FoodFrench"],
                FoodAmerican = (bool?)token["FoodAmerican"],
                FoodOther = (bool?)token["FoodOther"],
                GenrePop = (bool?)token["GenrePop"],
                GenreRB = (bool?)token["GenreRB"],
                GenreRap = (bool?)token["GenreRap"],
                GenreRock = (bool?)token["GenreRock"],
                GenreCountry = (bool?)token["GenreCountry"],
                GenreDance = (bool?)token["GenreDance"],
                GenreTechno = (bool?)token["GenreTechno"],
                GenreMetal = (bool?)token["GenreMetal"],
                GenreInternational = (bool?)token["GenreInternational"],
                GenreOther = (bool?)token["GenreOther"],
                Judaism = (bool?)token["Judaism"],
                Sikhism = (bool?)token["Sikhism"],
                Hinduism = (bool?)token["Hinduism"],
                Islamic = (bool?)token["Islamic"],
                NonDenominational = (bool?)token["NonDenominational"],
                Catholicism = (bool?)token["Catholicism"],
                Lutheranism = (bool?)token["Lutheranism"],
                Buddhism = (bool?)token["Buddhism"],
                ReligionOther = (bool?)token["ReligionOther"],
                CouplesId = (int?)token["CouplesId"],
                EstimatedTotal = (double?)token["EstimatedTotal"]
            };
            return package;
        }

        public ActionResult ChooseVendors(int? id)
        {
            var weddingPackages = PackageList();
            var package = weddingPackages.Where(w => w.CouplesId == id).Select(w => w).SingleOrDefault();
            return View(package);
        }

        public List<WeddingPackageViewModel> PackageList()
        {
            List<WeddingPackageViewModel> packageList = new List<WeddingPackageViewModel>();
            WeddingPackageViewModel package = new WeddingPackageViewModel();
            var userId = User.Identity.GetUserId();
            var couple = db.Couples.Where(c => c.ApplicationId == userId).Select(c => c).SingleOrDefault();
            var response = client.GetAsync("WeddingPackages");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JArray jObject = JArray.Parse(read.Result);
                foreach (var item in jObject)
                {
                    package = PackageModel(item);
                    if (package.CouplesId == couple.CoupleId)
                    {
                        packageList.Add(package);
                    }
                }
            }
            return packageList;
        }

        public WeddingPackageViewModel GetOneRequest(int? id)
        {
            WeddingPackageViewModel package = new WeddingPackageViewModel();
            var response = client.GetAsync("WeddingPackages/" + id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JObject jObject = JObject.Parse(read.Result);
                package = PackageModel(jObject);
            }
            return package;
        }

        public WeddingPackageViewModel SetNullValues(WeddingPackageViewModel package)
        {
            Type type = typeof(WeddingPackageViewModel);
            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                if (item.GetValue(package) == null)
                {
                    if (item.PropertyType.Equals(typeof(bool?)) == true)
                    {
                        item.SetValue(package, false);
                    }
                    else if (item.PropertyType.Equals(typeof(double?)) == true)
                    {
                        item.SetValue(package, 0.00);
                    }
                }
            }
            return package;
        }

        public ActionResult MakePackage()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Couples.Where(u => u.ApplicationId == userId).Select(u => u).SingleOrDefault();
            ViewBag.UserId = user.CoupleId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakePackage(WeddingPackageViewModel weddingPackage)
        {
            if (ModelState.IsValid)
            {
                weddingPackage = SetNullValues(weddingPackage);
                var userId = User.Identity.GetUserId();
                var user = db.Couples.Where(c => c.ApplicationId == userId).Select(c => c).SingleOrDefault();
                weddingPackage.CouplesId = user.CoupleId;
                string json = JsonConvert.SerializeObject(weddingPackage);
                var response = client.PostAsync("WeddingPackages", new StringContent(json, Encoding.UTF8, "application/json"));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Packages");
                }
            }
            return View();
        }

        public ActionResult Packages()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Couples.Where(c => c.ApplicationId == userId).Select(c => c).SingleOrDefault();
            var weddingPackages = PackageList();
            var packages = weddingPackages.Where(w => w.CouplesId == user.CoupleId).Select(w => w).ToList();
            ViewBag.PackageAmount = packages.Count;
            return View(packages);
        }

        public ActionResult PackageDetails(int? id)
        {
            var package = GetOneRequest(id);
            Type type = typeof(WeddingPackageViewModel);
            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                var x = item.GetValue(package);
                if (item.GetValue(package) == null)
                {
                    var yx = item.PropertyType;
                    if (item.PropertyType.Equals(typeof(bool?)) == true)
                    {
                        item.SetValue(package, false);
                    }
                    else if (item.PropertyType.Equals(typeof(double?)) == true)
                    {
                        item.SetValue(package, 0.00);
                    }
                }
            }
            return View(package);
        }

        public ActionResult EditPackage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingPackageViewModel package = GetOneRequest(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPackage(WeddingPackageViewModel weddingPackage)
        {
            if (ModelState.IsValid)
            {
                weddingPackage = SetNullValues(weddingPackage);
                var userId = User.Identity.GetUserId();
                var user = db.Couples.Where(c => c.ApplicationId == userId).Select(c => c).SingleOrDefault();
                weddingPackage.CouplesId = user.CoupleId;
                string json = JsonConvert.SerializeObject(weddingPackage);
                var response = client.PutAsync("WeddingPackages/" + weddingPackage.Id, new StringContent(json, Encoding.UTF8, "application/json"));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    weddingPackage = GetOneRequest(weddingPackage.Id);
                    return RedirectToAction("PackageDetails", new { id = weddingPackage.Id });
                }
            }
            return View(weddingPackage);
        }

        public ActionResult DeletePackage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingPackageViewModel package = new WeddingPackageViewModel();
            var response = client.GetAsync("WeddingPackages/" + id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var service = read.Result;
                JObject jObject = JObject.Parse(service);
                package = PackageModel(jObject);
            }
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Couples/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePackage(int id)
        {
            var response = client.DeleteAsync("WeddingPackages/" + id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Details");
            }
            return View(id);
        }

        public ActionResult SelectPackage(int? id, string type)
        {
            PackageViewModel package = new PackageViewModel();
            var response = client.GetAsync("VendorPackages/" + id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JObject vendorPackage = JObject.Parse(read.Result);
                package = new PackageViewModel()
                {
                    Id = (int)vendorPackage["Id"],
                    VendorType = (string)vendorPackage["VendorType"],
                    VendorId = (int)vendorPackage["VendorId"],
                    Description = (string)vendorPackage["Description"],
                    Price = (double)vendorPackage["Price"]
                };
            }
            return View();
        }

        private CoupleViewModel MakeModel(JToken item)
        {
            CoupleViewModel couple = new CoupleViewModel()
            {
                Id = (int)item["Id"],
                Partner1FirstName = (string)item["Partner1FirstName"],
                Partner1LastName = (string)item["Partner1LastName"],
                Partner2FirstName = (string)item["Partner2FirstName"],
                Partner2LastName = (string)item["Partner2LastName"],
                CoupleStreetAddress = (string)item["CoupleStreetAddress"],
                City = (string)item["City"],
                Zipcode = (int)item["Zipcode"],
                WeddingBudget = (double)item["WeddingBudget"],
                CoupleEmail = (string)item["CoupleEmail"],
                CouplePhone = (string)item["CouplePhone"]
            };
            return couple;
        }
        private List<CoupleViewModel> GetCouples()
        {
            List<CoupleViewModel> couplesList = new List<CoupleViewModel>();
            var response = client.GetAsync("Couples");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JArray couplesArray = JArray.Parse(read.Result);
                foreach (var item in couplesArray)
                {
                    var couple = MakeModel(item);
                    couplesList.Add(couple);
                }
            }
            return couplesList;
        }
        private CoupleViewModel GetOneCouple(int? id)
        {
            CoupleViewModel couple = new CoupleViewModel();
            var response = client.GetAsync("Couples/" + id);
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
            return couple;
        }

        // GET: Couples
        public ActionResult Index()
        {
            List<CoupleViewModel> couplesList = GetCouples();
            return View(couplesList);
        }

        // GET: Couples/Details/5
        public ActionResult Details(int? id)
        {
            CoupleViewModel couple = null;
            if (id == null)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Couples.Where(u => u.ApplicationId == userId).Select(u => u).SingleOrDefault();
                couple = Detail(user.CoupleId);
            }
            else
            {
                couple = Detail(id);
            }
            if (couple == null)
            {
                return HttpNotFound();
            }
            return View(couple);
        }

        public CoupleViewModel Detail(int? id)
        {
            CoupleViewModel couple = GetOneCouple(id);
            return couple;
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
        public ActionResult Create(CoupleViewModel service)
        {
            if (ModelState.IsValid)
            {
                Couple couple = new Couple();
                var userId = User.Identity.GetUserId();
                var applicationUser = db.Users.Where(u => u.Id == userId).Select(u => u).SingleOrDefault();
                service.CoupleEmail = applicationUser.Email;
                string json = JsonConvert.SerializeObject(service);
                var response = client.PostAsync("Couples", new StringContent(json, Encoding.UTF8, "application/json"));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    couple.ApplicationId = User.Identity.GetUserId();
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
                        couple.CoupleId = (int)lastObject["Id"];
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
            CoupleViewModel couple = GetOneCouple(id);
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
        public ActionResult Edit(CoupleViewModel couple)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(couple);
                var response = client.PutAsync("Couples/" + couple.Id, new StringContent(json, Encoding.UTF8, "application/json"));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var userId = User.Identity.GetUserId();
                    var currentUser = db.Couples.Where(v => v.ApplicationId == userId).Select(v => v).SingleOrDefault();
                    currentUser.CoupleId = couple.Id;
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = couple.Id });
                }
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
            var response = client.GetAsync("Couples/" + id);
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
            var response = client.DeleteAsync("Couples/" + id);
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
