﻿using System;
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