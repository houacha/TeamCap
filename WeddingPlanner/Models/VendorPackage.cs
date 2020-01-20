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
        public int PackageID { get; set; }

        [Display(Name = "VEndor Package Description")]
        public string PackageDescription { get; set; }

        [Display(Name = "Package Price")]
        public double PackagePrice { get; set; }

        [ForeignKey("VendorID")]
        public int VendorID { get; set; }
    }
}