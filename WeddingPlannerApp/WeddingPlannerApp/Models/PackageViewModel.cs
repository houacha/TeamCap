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
        public double? Price { get; set; }
        public int? PricePhaseKey { get; set; }
        public double? ContractPrice { get; set; }
        public int? VendorId { get; set; }
        public int? CoupleId { get; set; }
    }
}