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

        [Display(Name = "DJ's Email")]
        public string DJEmail { get; set; }

        [Display(Name = "DJ's Phone")]
        public string DJPhone { get; set; }

        [Display(Name = "Music Genres Offered")]
        public Dictionary<string,bool> MusicGenresOffered { get; set; }

        [Display(Name = "Will Travel")]
        public bool DoesTravel { get; set; }

        [Display(Name = "LGBTQ Friendly")]
        public bool LGBTQFriendly { get; set; }

      
    }
}