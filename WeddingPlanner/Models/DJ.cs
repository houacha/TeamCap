using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class DJ
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
        public bool GenrePop { get; set; }
        public bool GenreRB { get; set; }
        public bool GenreRap { get; set; }
        public bool GenreRock { get; set; }
        public bool GenreCountry { get; set; }
        public bool GenreDance { get; set; }
        public bool GenreTechno { get; set; }
        public bool GenreMetal { get; set; }
        public bool GenreInternational { get; set; }
        public bool GenreOther { get; set; }
        public bool DoesTravel { get; set; }
        public bool LGBTQFriendly { get; set; }

    }
}