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
        public string VendorType { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool LGBTQFriendly { get; set; }
        public bool KidFriendly { get; set; }
        public bool PetFriendly { get; set; }
        public bool HandicapAccessible { get; set; }
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
        public bool Ceremony { get; set; }
        public bool Reception { get; set; }
        public bool ProvidesLodging { get; set; }
        public bool AllowsDecor { get; set; }
        public bool ThirdPartyCelebrant { get; set; }
        public bool ThirdPartyCatering { get; set; }
        public bool ThirdPartyDJ { get; set; }
        public bool Caterers { get; set; }
        public int CatererId { get; set; }
    }
}