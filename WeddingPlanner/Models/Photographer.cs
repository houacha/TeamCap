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
        public string VendorType { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool DoesVideo { get; set; }
        public bool DoesEditing { get; set; }
        public bool LGBTQFriendly { get; set; }
        public bool DoesTravel { get; set; }
    }
}