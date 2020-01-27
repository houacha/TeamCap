using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Time")]
        public int TimeId { get; set; }
        public Time Time { get; set; }
    }
}