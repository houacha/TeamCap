using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Time
    {
        [Key]
        public int Id { get; set; }
        public string Hour { get; set; }
        public string Content { get; set; }
        [ForeignKey("Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }
    }
}