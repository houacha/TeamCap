using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class VendorPackage
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Package Price")]
        public double Price { get; set; }
        public int VendorId { get; set; }
    }
}