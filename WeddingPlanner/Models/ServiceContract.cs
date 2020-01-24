﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class ServiceContract
    {
        [Key]
        public int Id { get; set; }
        public string VendorType { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int PricePhaseKey { get; set; }
        public string ContractPrice { get; set; }
        public int CouplesId { get; set; }
        public int VendorId { get; set; }
    }
}