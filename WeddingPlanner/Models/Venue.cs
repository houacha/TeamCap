using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Venue
    {
        [Key]

        public int VendorId { get; set; }

        [Display(Name = "Venue Name")]
        public string Name { get; set; }

        [Display(Name = "Venue Email")]
        public string VenueEmail { get; set; }

        [Display(Name = "Venue Phone")]
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
        public string ReligionsServed { get; set; }

        [Display(Name = "Does it serve Cohabitants")]
        public bool ServesCohabitants { get; set; }

        [Display(Name = "Services Offered")]
        public string serviceOffered { get; set; }
        /*ceremony, reception, both*/

        [Display(Name = "Does it provide Lodging")]
        public bool ProvidesLodging { get; set; }

        [Display(Name = "Does it allow third-party decor")]
        public bool AllowsDecor { get; set; }

        [Display(Name = "Does it allow third-party Celebrant")]
        public bool ThirdPartyCelebrant { get; set; }

        [Display(Name = "Does it allow third-party Catering")]
        public bool ThirdPartyCatering { get; set; }

        [Display(Name = "Does it allow third-party DJ")]
        public bool ThirdPartyDJ { get; set; }

    }
}