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

        [Display(Name = "Caterer Name")]
        public string Name { get; set; }

        [Display(Name = "Caterer Email")]
        public string CatererEmail { get; set; }

        [Display(Name = "Caterer Phone")]
        public string CatererPhone { get; set; }

        [Display(Name = "LGBTQFriendly")]
        public bool LGBTQfriendly { get; set; }

        [Display(Name = "Cuisine types offered")]
        public string CuisineTypes { get; set; }

        [Display(Name = "VeganFriendly")]
        public bool ServesVegan { get; set; }

        [Display(Name = "Food Allergy Options catered")]
        public string FoodAllergyOptions { get; set; }

        [Display(Name = "Per Guest Estimate Low")]
        public double PerGuestEstimateLow { get; set; }

        [Display(Name = "Per Guest Estimated High")]
        public double PerGuestEstimateHigh { get; set; }

    }
}