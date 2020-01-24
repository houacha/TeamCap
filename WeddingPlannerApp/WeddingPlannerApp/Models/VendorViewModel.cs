using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlannerApp.Models
{
    public class VendorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Street")]
        [Required]
        public string Street { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "ZipCode")]
        [Required]
        public string Zip { get; set; }

        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "Does Video")]
        public bool? DoesVideo { get; set; }

        [Display(Name = "Does Editing")]
        public bool? DoesEditing { get; set; }

        [Display(Name = "LGBTQ Friendly")]
        public bool? LGBTQFriendly { get; set; }

        [Display(Name = "Will Travel")]
        public bool? DoesTravel { get; set; }

        [Display(Name = "Indian")]
        public bool? FoodIndian { get; set; }

        [Display(Name = "Italian")]
        public bool? FoodItalian { get; set; }

        [Display(Name = "Chinese")]
        public bool? FoodChinese { get; set; }

        [Display(Name = "Mediterranean")]
        public bool? FoodMediterranean { get; set; }

        [Display(Name = "Mexican")]
        public bool? FoodMexican { get; set; }

        [Display(Name = "French")]
        public bool? FoodFrench { get; set; }

        [Display(Name = "American")]
        public bool? FoodAmerican { get; set; }

        [Display(Name = "Other")]
        public bool? FoodOther { get; set; }

        [Display(Name = "Vegan Friendly")]
        public bool? ServesVegan { get; set; }

        [Display(Name = "Food Allergy Options")]
        public bool? FoodAllergyOptions { get; set; }

        [Display(Name = "Estimate Low Per Guest")]
        public double? PerGuestEstimateLow { get; set; }

        [Display(Name = "Estimated High Per Guest")]
        public double? PerGuestEstimateHigh { get; set; }

        [Display(Name = "Judaism")]
        public bool? Judaism { get; set; }

        [Display(Name = "Sikhism")]
        public bool? Sikhism { get; set; }

        [Display(Name = "Hinduism")]
        public bool? Hinduism { get; set; }

        [Display(Name = "Islamic")]
        public bool? Islamic { get; set; }

        [Display(Name = "Non-Denominational")]
        public bool? NonDenominational { get; set; }

        [Display(Name = "Catholicism")]
        public bool? Catholicism { get; set; }

        [Display(Name = "Lutheranism")]
        public bool? Lutheranism { get; set; }

        [Display(Name = "Buddhism")]
        public bool? Buddhism { get; set; }

        [Display(Name = "Other")]
        public bool? ReligionOther { get; set; }

        [Display(Name = "Pop")]
        public bool? GenrePop { get; set; }

        [Display(Name = "R&B")]
        public bool? GenreRB { get; set; }

        [Display(Name = "Rap")]
        public bool? GenreRap { get; set; }

        [Display(Name = "Rock")]
        public bool? GenreRock { get; set; }

        [Display(Name = "Country")]
        public bool? GenreCountry { get; set; }

        [Display(Name = "Dance")]
        public bool? GenreDance { get; set; }

        [Display(Name = "Techno")]
        public bool? GenreTechno { get; set; }

        [Display(Name = "Metal")]
        public bool? GenreMetal { get; set; }

        [Display(Name = "International")]
        public bool? GenreInternational { get; set; }

        [Display(Name = "Other")]
        public bool? GenreOther { get; set; } 

        [Display(Name = "Kid-friendly")]
        public bool? KidFriendly { get; set; }

        [Display(Name = "Pet-Friendly")]
        public bool? PetFriendly { get; set; }

        [Display(Name = "Wheelchair Accessible")]
        public bool? HandicapAccessible { get; set; }

        [Display(Name = "Serve Cohabitants")]
        public bool? ServesCohabitants { get; set; }

        [Display(Name = "Does Ceremony")]
        public bool? Ceremony { get; set; }

        [Display(Name = "Does Reception")]
        public bool? Reception { get; set; }

        [Display(Name = "Provides Lodging")]
        public bool? ProvidesLodging { get; set; }

        [Display(Name = "Allow third-party decor")]
        public bool? AllowsDecor { get; set; }

        [Display(Name = "Allow third-party Celebrant")]
        public bool? ThirdPartyCelebrant { get; set; }

        [Display(Name = "Allow third-party Catering")]
        public bool? ThirdPartyCatering { get; set; }

        [Display(Name = "Allow third-party DJ")]
        public bool? ThirdPartyDJ { get; set; }

        [Display(Name = "Does Cater")]
        public bool? Caterers { get; set; }
    }
}