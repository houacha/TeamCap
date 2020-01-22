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
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "ZipCode")]
        public string Zip { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Caterer's Email")]
        public string CatererEmail { get; set; }

        [Display(Name = "Caterer's Phone")]
        public string CatererPhone { get; set; }

        [Display(Name = "LGBTQ Friendly")]
        public bool LGBTQFriendly { get; set; }

        [Display(Name = "Indian")]
        public bool FoodIndian { get; set; }
        [Display(Name = "Italian")]
        public bool FoodItalian { get; set; }
        [Display(Name = "Chinese")]
        public bool FoodChinese { get; set; }
        [Display(Name = "Mediterranean")]
        public bool FoodMediterranean { get; set; }
        [Display(Name = "Mexican")]
        public bool FoodMexican { get; set; }
        [Display(Name = "French")]
        public bool FoodFrench { get; set; }
        [Display(Name = "American")]
        public bool FoodAmerican { get; set; }
        [Display(Name = "Other")]
        public bool FoodOther { get; set; }

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