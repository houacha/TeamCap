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
        public string VendorType { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool DoesTravel { get; set; }
        public bool Judaism { get; set; }
        public bool Sikhism { get; set; }
        public bool Hinduism { get; set; }
        public bool Islamic { get; set; }
        public bool NonDenominational { get; set; }
        public bool Catholicism { get; set; }
        public bool Lutheranism { get; set; }
        public bool Buddhism { get; set; }
        public bool ReligionOther { get; set; }
        public bool ServesCohabitants { get; set; }
        public bool LGBTQFriendly { get; set; }
    }
}