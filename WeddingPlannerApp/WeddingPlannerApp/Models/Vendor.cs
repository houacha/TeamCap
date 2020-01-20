using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlannerApp.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        public int VendorId { get; set; }
    }
}