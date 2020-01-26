using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Caterer
    {
        [Key]
        public int Id { get; set; }
        public string VendorType { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool LGBTQFriendly { get; set; }
        public bool FoodIndian { get; set; }
        public bool FoodItalian { get; set; }
        public bool FoodChinese { get; set; }
        public bool FoodMediterranean { get; set; }
        public bool FoodMexican { get; set; }
        public bool FoodFrench { get; set; }
        public bool FoodAmerican { get; set; }
        public bool FoodOther { get; set; }
        public bool ServesVegan { get; set; }
        public bool FoodAllergyOptions { get; set; }
        public double PerGuestEstimateLow { get; set; }
        public double PerGuestEstimateHigh { get; set; }

    }
}