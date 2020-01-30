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
        [ForeignKey("Year")]
        public int YearId { get; set; }
        public Year Year { get; set; }
    }
}