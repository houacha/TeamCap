using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class ServiceContract
    {
        [Key]
        public int ContractId { get; set; }
        [Display(Name = "Vendor Type")]
        public string VendorType { get; set; }
        [Display(Name = "Contract Description")]
        public string ContractDescription { get; set; }
        [Display(Name = "Contract Price")]
        public double Price { get; set; }
        public int PricePhaseKey { get; set; }
        public string ContractPrice { get; set; }
        public string CoupleName { get; set; }
        public string CouplePhone { get; set; }
        public string CoupleEmail { get; set; }
        //[ForeignKey("VendorID")]
        //public int VendorID { get; set; }
        //[ForeignKey("WeddingID")]
        //public int WeddingID { get; set; }
    }
}