using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class WeddingPackage
    {
        [Key]
        public int Id { get; set; }
        public bool AllowsDecor { get; set; }
        public bool ThirdPartyCelebrant { get; set; }
        public bool ThirdPartyCatering { get; set; }
        public bool ThirdPartyDJ { get; set; }
        public bool LGBTQFriendly { get; set; }
        public bool ServesCohabitants { get; set; }
        public bool KidFriendly { get; set; }
        public bool PetFriendly { get; set; }
        public bool WheelchairAccessible { get; set; }
        public bool FoodAllergyOptions { get; set; }
        public bool Vegan { get; set; }
        public bool FoodIndian { get; set; }
        public bool FoodItalian { get; set; }
        public bool FoodChinese { get; set; }
        public bool FoodMediterranean { get; set; }
        public bool FoodMexican { get; set; }
        public bool FoodFrench { get; set; }
        public bool FoodAmerican { get; set; }
        public bool FoodOther { get; set; }
        public bool GenrePop { get; set; }
        public bool GenreRB { get; set; }
        public bool GenreRap { get; set; }
        public bool GenreRock { get; set; }
        public bool GenreCountry { get; set; }
        public bool GenreDance { get; set; }
        public bool GenreTechno { get; set; }
        public bool GenreMetal { get; set; }
        public bool GenreInternational { get; set; }
        public bool GenreOther { get; set; }
        public bool Judaism { get; set; }
        public bool Sikhism { get; set; }
        public bool Hinduism { get; set; }
        public bool Islamic { get; set; }
        public bool NonDenominational { get; set; }
        public bool Catholicism { get; set; }
        public bool Lutheranism { get; set; }
        public bool Buddhism { get; set; }
        public bool ReligionOther { get; set; }
        public double EstimatedTotal { get; set; }
        [ForeignKey("Couple")]
        public int CouplesId { get; set; }
        public Couple Couple { get; set; }
    }
}