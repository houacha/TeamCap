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