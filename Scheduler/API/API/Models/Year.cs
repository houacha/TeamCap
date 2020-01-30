using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }
        public string TheYear { get; set; }
    }
}