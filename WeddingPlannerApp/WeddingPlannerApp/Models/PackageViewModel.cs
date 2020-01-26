using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlannerApp.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [Required]
        public double Price { get; set; }
        public int? PricePhaseKey { get; set; }
        public string ContractPrice { get; set; }
        public string CoupleName { get; set; }
        public string CouplePhone { get; set; }
        public string CoupleEmail { get; set; }
        public int? VendorId { get; set; }
        public string Type { get; set; }
        public int PackageId { get; set; }
    }
}