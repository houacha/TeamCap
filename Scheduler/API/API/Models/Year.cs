﻿using System;
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
        public int TheYear { get; set; }
        [ForeignKey("Month")]
        public int MonthId { get; set; }
        public Month Month { get; set; }
    }
}