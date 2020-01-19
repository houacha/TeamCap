using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class Photographer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Photographer Name")]
        public string Name { get; set; }

        [Display(Name = "Photographer's Email")]
        public string PhotographerEmail { get; set; }

        [Display(Name = "Photographer's Phone")]
        public int PhotographerPhone { get; set; }

        [Display(Name = "Is Video service offered")]
        public bool DoesVideo { get; set; }

        [Display(Name = "Is Editing service offered")]
        public bool DoesEditing { get; set; }

        [Display(Name = "LGBTQFriendly")]
        public bool ServesLGBTQ { get; set; }

        [Display(Name = "Ready To Travel")]
        public bool DoesTravel { get; set; }

       
    }
}