using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Couple
    {
        [Key]
        public int Id { get; set; }
        public string Partner1FirstName { get; set; }
        public string Partner1LastName { get; set; }
        public string Partner2FirstName { get; set; }
        public string Partner2LastName { get; set; }
        public string CoupleStreetAddress { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public double WeddingBudget { get; set; }
        public string CoupleEmail { get; set; }
        public string CouplePhone { get; set; }
        public int WeddingId { get; set; }

    }
}