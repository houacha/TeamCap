using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Month
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }
    }
}