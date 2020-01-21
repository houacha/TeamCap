using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class WeddingPackage
    {
        [Key]
        public int WeddingId { get; set; }

        [Display(Name = "Allows third party vendors?")]
        public bool ThirdPartyVendors { get; set; }

        [Display(Name = "LGBTQ Friendly?")]
        public bool LGBTQFriendly { get; set; }

        [Display(Name = "Co Habitants?")]
        public bool ServesCohabitants { get; set; }

        [Display(Name = "Kid Friendly?")]
        public bool KidFriendly { get; set; }

        [Display(Name = "Pet Friendly?")]
        public bool PetFriendly { get; set; }

        [Display(Name = "Wheelchair Accessible?")]
        public bool WheelchairAccessible { get; set; }

        [Display(Name = "Food Allergy Options")]
        public bool FoodAllergyOptions { get; set; }

        [Display(Name = "Vegan")]
        public bool Vegan { get; set; }

        [Display(Name = "Cuisine Type Requirements")]
        public Dictionary<string,bool> CuisineTypes { get; set; }

        [Display(Name = "Music Genres Requirements")]
        public Dictionary<string,bool> MusicGenres { get; set; }

        [Display(Name = "Religious service Requirement")]
        public Dictionary<string,bool> ReligiousService { get; set; }


    }
}