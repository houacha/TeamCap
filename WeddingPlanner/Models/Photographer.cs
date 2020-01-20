using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Photographer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }

        [Display(Name = "Photographer's Name")]
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

        [Display(Name = "Photographer's Email")]
        public string PhotographerEmail { get; set; }

        [Display(Name = "Photographer's Phone")]
        public string PhotographerPhone { get; set; }

        [Display(Name = "Does Video")]
        public bool DoesVideo { get; set; }

        [Display(Name = "Does Editing")]
        public bool DoesEditing { get; set; }

        [Display(Name = "LGBTQ Friendly")]
        public bool LGBTQFriendly { get; set; }

        [Display(Name = "Will Travel")]
        public bool DoesTravel { get; set; }

       
    }
}