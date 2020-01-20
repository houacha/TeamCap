using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Venue
    {
        [Key]
        public int VendorId { get; set; }

        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }

        [Display(Name = "Venue's Name")]
        public string Name { get; set; }

        [Display(Name = "Venue's Email")]
        public string VenueEmail { get; set; }

        [Display(Name = "Venue's Phone")]
        public string VenuePhone { get; set; }

        [Display(Name = "LGBTQ friendly")]
        public bool LGBTQFriendly { get; set; }

        [Display(Name = "Kid-friendly")]
        public bool KidFriendly { get; set; }

        [Display(Name = "Pet-Friendly")]
        public bool PetFriendly { get; set; }

        [Display(Name = "Wheelchair Accessible")]
        public bool HandicapAccessible { get; set; }

        [Display(Name = "Religions served")]
        public Dictionary<string,bool> ReligionsServed { get; set; }

        [Display(Name = "Serve Cohabitants")]
        public bool ServesCohabitants { get; set; }

        [Display(Name = "Does Ceremony")]
        public bool Ceremony { get; set; }
        [Display(Name = "Does Reception")]
        public bool Reception { get; set; }

        [Display(Name = "Provides Lodging")]
        public bool ProvidesLodging { get; set; }

        [Display(Name = "Allow third-party decor")]
        public bool AllowsDecor { get; set; }

        [Display(Name = "Allow third-party Celebrant")]
        public bool ThirdPartyCelebrant { get; set; }

        [Display(Name = "Allow third-party Catering")]
        public bool ThirdPartyCatering { get; set; }

        [Display(Name = "Allow third-party DJ")]
        public bool ThirdPartyDJ { get; set; }
        [Display(Name = "Does Cater")]
        public bool Caters { get; set; }
        [ForeignKey("Caterer")]
        public int CatererId { get; set; }
        public Caterer Caterer { get; set; }

    }
}