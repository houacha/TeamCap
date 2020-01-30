using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Content { get; set; }
    }
}