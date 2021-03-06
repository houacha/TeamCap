﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlannerApp.Models
{
    public class CoupleViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Partner One First Name")]
        [Required]
        public string Partner1FirstName { get; set; }

        [Display(Name = "Partner One Last Name")]
        [Required]
        public string Partner1LastName { get; set; }

        [Display(Name = "Partner Two First Name")]
        [Required]
        public string Partner2FirstName { get; set; }

        [Display(Name = "Partner Two Last Name")]
        [Required]
        public string Partner2LastName { get; set; }

        [Display(Name = "Street Address")]
        [Required]
        public string CoupleStreetAddress { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Zipcode")]
        [Required]
        public int Zipcode { get; set; }

        [Display(Name = "Wedding Budget")]
        public double WeddingBudget { get; set; }

        [Display(Name = "Email")]
        public string CoupleEmail { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string CouplePhone { get; set; }
    }
}
