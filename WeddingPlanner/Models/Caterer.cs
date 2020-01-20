using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Caterer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name= "Vendor Type")]
        public string VendorType { get; set; }

        [Display(Name = "Caterer's Name")]
        public string Name { get; set; }

        [Display(Name = "Caterer's Email")]
        public string CatererEmail { get; set; }

        [Display(Name = "Caterer's Phone")]
        public string CatererPhone { get; set; }

        [Display(Name = "LGBTQ Friendly")]
        public bool LGBTQfriendly { get; set; }

        [Display(Name = "Cuisine types offered")]
        public Dictionary<string,bool> CuisineTypes { get; set; }

        [Display(Name = "Vegan Friendly")]
        public bool ServesVegan { get; set; }

        [Display(Name = "Food Allergy Options")]
        public bool FoodAllergyOptions { get; set; }

        [Display(Name = "Estimate Low Per Guest")]
        public double PerGuestEstimateLow { get; set; }

        [Display(Name = "Estimated High Per Guest")]
        public double PerGuestEstimateHigh { get; set; }

    }
}