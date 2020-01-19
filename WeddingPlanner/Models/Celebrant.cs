using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Celebrant
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Celebrant's Name")]
        public string Name { get; set; }

        [Display(Name = "Celebrant Email")]
        public string CelebrantEmail { get; set; }

        [Display(Name = "Celebrant Phone")]
        public int CelebrantPhone { get; set; }

        [Display(Name = "Ready to travel")]
        public bool DoesTravel { get; set; }

        [Display(Name = "Religious services offered")]
        public string ReligionsServed { get; set; }

        [Display(Name = "Do they sevice Co-habitants")]
        public bool ServicesCohabitants { get; set; }

        [Display(Name = "LGBTQFriendly")]
        public bool LGBTQFriendly { get; set; }

       
    }
}