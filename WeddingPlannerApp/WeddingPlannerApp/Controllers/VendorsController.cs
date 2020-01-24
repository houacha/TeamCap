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
using System.Text;
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
            client.BaseAddress = new Uri("https://localhost:44317/api/");
        }

        #region Vendor Methods

        // Makes a model to hold API info of vendors
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
                Email = (string)item["Email"],
                Phone = (string)item["Phone"],
                DoesVideo = (bool?)item["DoesVideo"],
                DoesEditing = (bool?)item["DoesEditing"],
                LGBTQFriendly = (bool?)item["LGBTQFriendly"],
                DoesTravel = (bool?)item["DoesTravel"],
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
                Judaism = (bool?)item["Judaism"],
                Sikhism = (bool?)item["Sikhism"],
                Hinduism = (bool?)item["Hinduism"],
                Islamic = (bool?)item["Islamic"],
                NonDenominational = (bool?)item["NonDenominational"],
                Catholicism = (bool?)item["Catholicism"],
                Lutheranism = (bool?)item["Lutheranism"],
                Buddhism = (bool?)item["Buddhism"],
                ReligionOther = (bool?)item["ReligionOther"],
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
        
        // Makes the API request for get all vendors
        private List<VendorViewModel> GetRequest(string type)
        {
            List<VendorViewModel> vendorList = new List<VendorViewModel>();
            var response = client.GetAsync(type);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JArray venueArray = JArray.Parse(read.Result);
                foreach (var item in venueArray)
                {
                    var vendor = MakeModel(item);
                    vendorList.Add(vendor);
                }
            }
            return vendorList;
        }

        // Makes the API request for get one vendor
        private VendorViewModel GetOneRequest(string type, int? id)
        {
            VendorViewModel vendor = new VendorViewModel();
            var response = client.GetAsync(type + "s" + "/" + id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JObject jObject = JObject.Parse(read.Result);
                vendor = MakeModel(jObject);
            }
            return vendor;
        }

        // Make Vendors For MVC
        public ActionResult DecideVendorType()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DecideVendorType(Vendor vendor)
        {
            var userId = User.Identity.GetUserId();
            vendor.ApplicationId = userId;
            db.Vendors.Add(vendor);
            db.SaveChanges();
            return RedirectToAction("Create", "Vendors", new { type = vendor.VendorType });
        }

        // get info of all vendor
        public ActionResult Index(string type)
        {
            var vendorList = GetRequest(type);
            ViewBag.VenderType = type;
            return View(vendorList);
        }

        // Shows Details of vendor
        public ActionResult Details(int? id, string type)
        {
            VendorViewModel vendor = null;
            if (id == null)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Vendors.Where(u => u.ApplicationId == userId).Select(u => u).SingleOrDefault();
                vendor = Detail(user.VendorId, user.VendorType);
                ViewBag.VendorType = user.VendorType + "s";
            }
            else
            {
                vendor = Detail(id, type);
                ViewBag.VendorType = type + "s";
            }
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // Gets the info of a vendor
        private VendorViewModel Detail(int? id, string type)
        {
            VendorViewModel vendor = new VendorViewModel();
            var response = client.GetAsync(type + "s" + "/" + id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JObject jObject = JObject.Parse(read.Result);
                vendor = MakeModel(jObject);
            }
            return vendor;
        }

        // makes vendor for the API
        public ActionResult Create(string type)
        {
            ViewBag.VendorType = type + "s";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorViewModel service)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var applicationUser = db.Users.Where(u => u.Id == userId).Select(u => u).SingleOrDefault();
                var type = db.Vendors.Where(v => v.ApplicationId == userId).Select(v => v.VendorType).SingleOrDefault();
                service.Email = applicationUser.Email;
                service.VendorType = type;
                string json = JsonConvert.SerializeObject(service);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(service.VendorType + "s", content);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var currentUser = User.Identity.GetUserId();
                    var user = db.Vendors.Where(v => v.ApplicationId == currentUser).Select(v => v).SingleOrDefault();
                    var last = GetRequest(service.VendorType + "s");
                    user.VendorId = last.Last().Id;
                    user.VendorType = service.VendorType;
                    db.SaveChanges();
                }
                return RedirectToAction("LogOut", "Account");
            }
            ViewBag.VenderType = service.VendorType + "s";
            return View(service);
        }

        // Edit a specific vendor for the API
        public ActionResult Edit(int? id, string type)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vendor = GetOneRequest(type + "s", id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorType = type + "s";
            return View(vendor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorViewModel vendor)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var user = db.Vendors.Where(v => v.ApplicationId == id).Select(v => v).SingleOrDefault();
                vendor.VendorType = user.VendorType;
                string json = JsonConvert.SerializeObject(vendor);
                var response = client.PutAsync(vendor.VendorType + "s" + "/" + vendor.Id, new StringContent(json, Encoding.UTF8, "application/json"));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    user.VendorId = vendor.Id;
                    user.VendorType = vendor.VendorType;
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = vendor.Id, type = vendor.VendorType });
                }
            }
            ViewBag.VenderType = vendor.VendorType + "s";
            return View(vendor);
        }

        // Deletes a specific vendor for both databases
        public ActionResult Delete(int? id, string type)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vendor = GetOneRequest(type, id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorType = vendor.VendorType + "s";
            return View(vendor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string type)
        {
            var response = client.DeleteAsync(type + "s" + "/" + id);
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
            return RedirectToAction("LogOut", "Account");
        }

        #endregion

        #region Package Methods

        // Makes a get request for a specific package
        public PackageViewModel RequestPackage(int? id)
        {
            PackageViewModel package = null;
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
            return package;
        }

        // Shows the list of all packages
        public ActionResult GetPackage(int? id, string type)
        {
            List<PackageViewModel> packages = new List<PackageViewModel>();
            var response = client.GetAsync("VendorPackages");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                JArray vendorPackages = JArray.Parse(read.Result);
                foreach (var item in vendorPackages)
                {
                    PackageViewModel package = new PackageViewModel()
                    {
                        Id = (int)item["Id"],
                        VendorType = (string)item["VendorType"],
                        VendorId = (int)item["VendorId"],
                        Description = (string)item["Description"],
                        Price = (double)item["Price"]
                    };
                    if (package.VendorId == id && package.VendorType == type)
                    {
                        packages.Add(package);
                    }
                }
            }
            ViewBag.VendorType = type;
            return View(packages);
        }

        // Shows a specific package
        public ActionResult GetOnePackage(int? id)
        {
            var package = RequestPackage(id);
            return View(package);
        }

        // Makes a package for the API
        public ActionResult MakePackage()
        {
            var userId = User.Identity.GetUserId();
            var applicationUser = db.Users.Where(u => u.Id == userId).Select(u => u).SingleOrDefault();
            var vendor = db.Vendors.Where(v => v.ApplicationId == userId).Select(v => v).SingleOrDefault();
            ViewBag.Id = vendor.VendorId;
            ViewBag.Type = vendor.VendorType;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakePackage(PackageViewModel package)
        {
            var userId = User.Identity.GetUserId();
            var applicationUser = db.Users.Where(u => u.Id == userId).Select(u => u).SingleOrDefault();
            var vendor = db.Vendors.Where(v => v.ApplicationId == userId).Select(v => v).SingleOrDefault();
            package.VendorType = vendor.VendorType;
            package.VendorId = vendor.VendorId;
            string json = JsonConvert.SerializeObject(package);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("VendorPackages", content);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = vendor.VendorId, type = package.VendorType });
            }
            ViewBag.Id = vendor.VendorId;
            ViewBag.Type = vendor.VendorType;
            return View(package);
        }

        // Edits a specific package
        public ActionResult EditPackage(int? id)
        {
            var package = RequestPackage(id);
            return View(package);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPackage(PackageViewModel package)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var user = db.Vendors.Where(v => v.ApplicationId == id).Select(v => v).SingleOrDefault();
                package.VendorType = user.VendorType;
                string json = JsonConvert.SerializeObject(package);
                var response = client.PutAsync(package.VendorType + "s" + "/" + package.Id, new StringContent(json, Encoding.UTF8, "application/json"));
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetOnePackage", new { id = package.VendorId });
                }
            }
            return View(package);
        }

        // Deletes a specific package from the API
        public ActionResult DeletePackage(int? id)
        {
            PackageViewModel package = null;

            return View(package);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePackage(int? id, PackageViewModel package)
        {
            var response = client.DeleteAsync("VendorPackages/" + id);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {

            }
            return RedirectToAction("Details", new { id = package.VendorId, type = package.VendorType });
        }

        #endregion

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
