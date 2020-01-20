using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Couple
    {

        [Key]

        public int Id { get; set; }

        [Display(Name = "Partner One's First Name")]
        public string Partner1FirstName { get; set; }

        [Display(Name = "Partner One's Last Name")]
        public string Partner1LastName { get; set; }

        [Display(Name = "Partner Two's First Name")]
        public string Partner2FirstName { get; set; }

        [Display(Name = "Partner Two's Last Name")]
        public string Partner2LastName { get; set; }

        [Display(Name = "Street Address")]
        public string CoupleStreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zipcode")]
        public int Zipcode { get; set; }

        [Display(Name = "Wedding Budget")]
        public double WeddingBudget { get; set; }

        [Display(Name = "Estimated Total Cost")]
        public double EstimatedTotal { get; set; }

        [Display(Name = "Email")]
        public string CoupleEmail { get; set; }

        [Display(Name = "Phone")]
        public string CouplePhone { get; set; }

    }
}