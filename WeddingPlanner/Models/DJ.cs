using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class DJ
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "DJ Email")]
        public string DJEmail { get; set; }

        [Display(Name = "DJ Phone")]
        public string DJPhone { get; set; }

        [Display(Name = "Music Genres Offered")]
        public bool MusicGenresOffered { get; set; }

        [Display(Name = "Ready To Travel")]
        public bool DoesTravel { get; set; }

        [Display(Name = "LGBTQFriendly")]
        public bool LGBTQFriendly { get; set; }

      
    }
}