using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class DJ
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }
        [Display(Name = "Name")]
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
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Pop")]
        public bool GenrePop { get; set; }
        [Display(Name = "R&B")]
        public bool GenreRB { get; set; }
        [Display(Name = "Rap")]
        public bool GenreRap { get; set; }
        [Display(Name = "Rock")]
        public bool GenreRock { get; set; }
        [Display(Name = "Country")]
        public bool GenreCountry { get; set; }
        [Display(Name = "Dance")]
        public bool GenreDance { get; set; }
        [Display(Name = "Techno")]
        public bool GenreTechno { get; set; }
        [Display(Name = "Metal")]
        public bool GenreMetal { get; set; }
        [Display(Name = "Other")]
        public bool GenreInternational { get; set; }
        [Display(Name = "International")]
        public bool GenreOther { get; set; }

        [Display(Name = "Will Travel")]
        public bool DoesTravel { get; set; }

        [Display(Name = "LGBTQ Friendly")]
        public bool LGBTQFriendly { get; set; }


    }
}