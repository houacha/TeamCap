using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class CancelToken
    {
        [Key]
        public int Id { get; set; }
        public string VendorType { get; set; }
        public int VendorId { get; set; }
        public double price { get; set; }
        public string CancelPerson { get; set; }
        [ForeignKey("Couple")]
        public int CoupleId { get; set; }
        public Couple Couple { get; set; }
    }
}