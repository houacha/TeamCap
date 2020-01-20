using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlannerApp.Models
{
    public class Couple
    {
        [Key]
        public int Id { get; set; }
        public int CoupleId { get; set; }
    }
}