using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlannerApp.Models
{
    public class CancelViewModel
    {
        [Key]
        public int Id { get; set; }
        public string VendorType { get; set; }
        public int? VendorId { get; set; }
        public double? Price { get; set; }
        public string CancelPerson { get; set; }
        public int? CoupleId { get; set; }
    }
}