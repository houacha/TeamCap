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
using System.Reflection;
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

        public VendorViewModel SetNullValues(VendorViewModel vendor)
        {
            Type type = typeof(VendorViewModel);
            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                if (item.GetValue(vendor) == null)
                {
                    if (item.PropertyType.Equals(typeof(bool?)) == true)
                    {
                        item.SetValue(vendor, false);
                    }
                    else if (item.PropertyType.Equals(typeof(double?)) == true)
                    {
                        item.SetValue(vendor, 0.0);
                    }
                }
            }
            return vendor;
        }

        // Makes the API request for get all vendors
        private List<VendorViewModel> GetRequest(string type)
        {
            List<VendorViewModel> vendorList = new List<VendorViewModel>();
            var response = client.GetAsync(type + "s");
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
        private List<WeddingPackageViewModel> GetWedding()
        {
            List<WeddingPackageViewModel> packageList = new List<WeddingPackageViewModel>();
            WeddingPackageViewModel package = new WeddingPackageViewModel();
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
                    packageList.Add(package);
                }
            }
            return packageList;
        }

        private Dictionary<string, bool?> GetListOfTrueReliForVendor(object model)
        {
            Dictionary<string, bool?> trueVal = new Dictionary<string, bool?>();
            Type propType = typeof(VendorViewModel);
            PropertyInfo[] properties = propType.GetProperties();
            List<string> religions = new List<string>() { "Sikhism", "ReligionOther", "NonDenominational", "Lutheranism", "Buddhism", "Catholicism", "Hinduism", "Islamic", "Judaism" };
            foreach (var prop in properties)
            {
                if (prop.GetValue(model) == null)
                {
                }
                else
                {
                    if (prop.PropertyType.Equals(typeof(bool?)) == true && prop.GetValue(model).Equals(true) && religions.Contains(prop.Name))
                    {
                        trueVal.Add(prop.Name, Convert.ToBoolean(prop.GetValue(model)));
                    }
                }
            }
            return trueVal;
        }

        private Dictionary<string, bool?> GetListOfTrueReliForWedding(object model)
        {
            Dictionary<string, bool?> trueVal = new Dictionary<string, bool?>();
            Type propType = typeof(WeddingPackageViewModel);
            PropertyInfo[] properties = propType.GetProperties();
            List<string> religions = new List<string>() { "Sikhism", "ReligionOther", "NonDenominational", "Lutheranism", "Buddhism", "Catholicism", "Hinduism", "Islamic", "Judaism" };
            foreach (var prop in properties)
            {
                if (prop.PropertyType.Equals(typeof(bool?)) == true && prop.GetValue(model).Equals(true) && religions.Contains(prop.Name))
                {
                    trueVal.Add(prop.Name, Convert.ToBoolean(prop.GetValue(model)));
                }
            }
            return trueVal;
        }

        // get info of all vendor
        public ActionResult Index(string type, int? id)
        {
            var vendorList = GetRequest(type);
            var weddingList = GetWedding();
            var userId = User.Identity.GetUserId();
            var coupleId = db.Couples.Where(c => c.ApplicationId == userId).Select(c => c.CoupleId).SingleOrDefault();
            var couplesPackage = weddingList.Where(w => w.CouplesId == coupleId && w.Id == id).Select(w => w).SingleOrDefault();
            var trueValOfCoupleRelig = GetListOfTrueReliForWedding(couplesPackage);
            List<VendorViewModel> packages = new List<VendorViewModel>();
            foreach (var item in vendorList)
            {
                var itemPropList = GetListOfTrueReliForVendor(item);

                switch (type)
                {
                    case "Venue":
                        foreach (var property in trueValOfCoupleRelig)
                        {
                            var count = 0;
                            foreach (var prop in itemPropList)
                            {
                                if ((prop.Key == property.Key && prop.Value == property.Value) && (item.LGBTQFriendly == couplesPackage.LGBTQFriendly))
                                {
                                    if ((couplesPackage.ThirdPartyCatering == true && couplesPackage.ThirdPartyCatering == item.ThirdPartyCatering) &&
                                        (couplesPackage.ThirdPartyCelebrant == true && couplesPackage.ThirdPartyCelebrant == item.ThirdPartyCelebrant) &&
                                        (couplesPackage.ThirdPartyDJ == true && couplesPackage.ThirdPartyDJ == item.ThirdPartyDJ) &&
                                        (couplesPackage.KidFriendly == true && couplesPackage.KidFriendly == item.KidFriendly) &&
                                        (couplesPackage.PetFriendly == true && couplesPackage.PetFriendly == item.PetFriendly) &&
                                        (couplesPackage.ServesCohabitants == true && couplesPackage.ServesCohabitants == item.ServesCohabitants) &&
                                        (couplesPackage.WheelchairAccessible == true && couplesPackage.WheelchairAccessible == item.HandicapAccessible))
                                    {
                                        count++;
                                    }
                                }
                            }
                            if (count == trueValOfCoupleRelig.Count)
                            {
                                packages.Add(item);
                                count = 0;
                            }
                        }
                        break;
                    case "DJ":
                        if ((item.GenreTechno == couplesPackage.GenreTechno || item.GenreRock == couplesPackage.GenreRock ||
                item.GenreRB == couplesPackage.GenreRB || item.GenreRap == couplesPackage.GenreRap ||
                item.GenrePop == couplesPackage.GenrePop || item.GenreOther == couplesPackage.GenreOther ||
                item.GenreMetal == couplesPackage.GenreMetal || item.GenreInternational == couplesPackage.GenreInternational ||
                item.GenreDance == couplesPackage.GenreDance || item.GenreCountry == couplesPackage.GenreCountry) &&
                (item.LGBTQFriendly == couplesPackage.LGBTQFriendly))
                        {
                            packages.Add(item);
                        }
                        break;
                    case "Celebrant":
                        foreach (var property in trueValOfCoupleRelig)
                        {
                            var count = 0;
                            foreach (var prop in itemPropList)
                            {
                                if ((prop.Key == property.Key && prop.Value == property.Value) && (item.LGBTQFriendly == couplesPackage.LGBTQFriendly) &&
                                    (couplesPackage.ServesCohabitants == true && couplesPackage.ServesCohabitants == item.ServesCohabitants))
                                {
                                    count++;
                                }
                            }
                            if (count == trueValOfCoupleRelig.Count)
                            {
                                packages.Add(item);
                                count = 0;
                            }
                        }
                        break;
                    case "Caterer":
                        if ((item.FoodOther == couplesPackage.FoodOther || item.FoodMexican == couplesPackage.FoodMexican ||
                item.FoodMediterranean == couplesPackage.FoodMediterranean || item.FoodItalian == couplesPackage.FoodItalian ||
                item.FoodIndian == couplesPackage.FoodIndian || item.FoodFrench == couplesPackage.FoodFrench ||
                item.FoodChinese == couplesPackage.FoodChinese || item.FoodAmerican == couplesPackage.FoodAmerican) &&
                (item.LGBTQFriendly == couplesPackage.LGBTQFriendly) && (couplesPackage.Vegan == true && item.ServesVegan == couplesPackage.Vegan) &&
                (couplesPackage.FoodAllergyOptions == true && item.FoodAllergyOptions == couplesPackage.FoodAllergyOptions))
                        {
                            packages.Add(item);
                        }
                        break;
                    case "Photographer":
                        if (item.LGBTQFriendly == couplesPackage.LGBTQFriendly)
                        {
                            packages.Add(item);
                        }
                        break;
                    default:
                        break;
                }
            }
            ViewBag.VenderType = type + "s";
            return View(packages);
        }

        // Shows Details of vendor
        public ActionResult Details(int? id, string type)
        {
            VendorViewModel vendor = null;
            if (id == null)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Vendors.Where(u => u.ApplicationId == userId).Select(u => u).SingleOrDefault();
                vendor = GetOneRequest(user.VendorType, user.VendorId);
                ViewBag.VendorType = user.VendorType;
            }
            else
            {
                vendor = GetOneRequest(type, id);
                ViewBag.VendorType = type + "s";
            }
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
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
            var userId = User.Identity.GetUserId();
            var applicationUser = db.Users.Where(u => u.Id == userId).Select(u => u).SingleOrDefault();
            var type = db.Vendors.Where(v => v.ApplicationId == userId).Select(v => v.VendorType).SingleOrDefault();
            if (ModelState.IsValid)
            {
                service = SetNullValues(service);
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
                    var last = GetRequest(service.VendorType);
                    user.VendorId = last.Last().Id;
                    user.VendorType = service.VendorType;
                    db.SaveChanges();
                }
                return RedirectToAction("LogOut", "Account");
            }
            return RedirectToAction("Create", new { type = type });
        }

        // Edit a specific vendor for the API
        public ActionResult Edit(int? id, string type)
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
            ViewBag.VendorType = type + "s";
            return View(vendor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorViewModel vendor)
        {
            if (ModelState.IsValid)
            {
                vendor = SetNullValues(vendor);
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
                    else if (type == "Couples")
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
