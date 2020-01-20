using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Celebrant
    {
        [Key]

        public int Id { get; set; }
        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }
        [Display(Name = "Celebrant's Name")]
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

        [Display(Name = "Celebrant's Email")]
        public string CelebrantEmail { get; set; }

        [Display(Name = "Celebrant's Phone")]
        public string CelebrantPhone { get; set; }

        [Display(Name = "Will Travel")]
        public bool DoesTravel { get; set; }

        [Display(Name = "Religious services offered")]
        public Dictionary<string,bool> ReligionsServed { get; set; }
        
        [Display(Name = "Sevices Co-habitants")]
        public bool ServicesCohabitants { get; set; }

        [Display(Name = "LGBTQ Friendly")]
        public bool LGBTQFriendly { get; set; }

       
    }
}