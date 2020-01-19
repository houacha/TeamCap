using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class ServiceContract
    {
        [Key]
        public int ContractId { get; set; }

        [Display(Name = "Contract Description")]
        public string ContractDescription { get; set; }

        [Display(Name = "Contract Price")]
        public string ContractPrice { get; set; }
    }
}