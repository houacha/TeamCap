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

        [Display(Name = "LGBTQ friendly")]
        public bool LGBTQFriendly { get; set; }

        [Display(Name = "Kid-friendly")]
        public bool KidFriendly { get; set; }

        [Display(Name = "Pet-Friendly")]
        public bool PetFriendly { get; set; }

        [Display(Name = "Wheelchair Accessible")]
        public bool HandicapAccessible { get; set; }

        [Display(Name = "Judaism")]
        public bool Judaism { get; set; }
        [Display(Name = "Sikhism")]
        public bool Sikhism { get; set; }
        [Display(Name = "Hinduism")]
        public bool Hinduism { get; set; }
        [Display(Name = "Islamic")]
        public bool Islamic { get; set; }
        [Display(Name = "Non-Denominational")]
        public bool NonDenominational { get; set; }
        [Display(Name = "Catholicism")]
        public bool Catholicism { get; set; }
        [Display(Name = "Lutheranism")]
        public bool Lutheranism { get; set; }
        [Display(Name = "Buddhism")]
        public bool Buddhism { get; set; }
        [Display(Name = "Other")]
        public bool ReligionOther { get; set; }

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
        public bool Caterers { get; set; }
        public int CatererId { get; set; }
    }
}