namespace WeddingPlanner.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WeddingPlanner.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WeddingPlanner.Models.ApplicationDbContext context)
        {
            //DJs
            Dictionary<string, bool> MusicGenres = new Dictionary<string, bool>();
            MusicGenres.Add("Pop", false);
            MusicGenres.Add("R&B", false);
            MusicGenres.Add("Rap", false);
            MusicGenres.Add("Rock", false);
            MusicGenres.Add("Country", false);
            MusicGenres.Add("Dance", false);
            MusicGenres.Add("Techno", false);
            MusicGenres.Add("Metal", false);
            MusicGenres.Add("International", false);
            MusicGenres.Add("Other", false);
            Models.DJ Bear = new Models.DJ { VendorType = "DJ", DJEmail = "musicBear@gmail.com", DJPhone = "111-333-4567", LGBTQFriendly = true, DoesTravel = false, MusicGenresOffered = MusicGenres };
            Bear.MusicGenresOffered["Pop"] = true;
            Bear.MusicGenresOffered["Rap"] = true;
            Bear.MusicGenresOffered["Techno"] = true;
            Models.DJ Bird = new Models.DJ { VendorType = "DJ", DJEmail = "musicBird@gmail.com", DJPhone = "222-333-4567", LGBTQFriendly = true, DoesTravel = true, MusicGenresOffered = MusicGenres };
            Bird.MusicGenresOffered["Rock"] = true;
            Bird.MusicGenresOffered["Country"] = true;
            Bird.MusicGenresOffered["Techno"] = true;
            Models.DJ Bruce = new Models.DJ { VendorType = "DJ", DJEmail = "musicBruce@gmail.com", DJPhone = "333-333-4567", LGBTQFriendly = false, DoesTravel = true, MusicGenresOffered = MusicGenres };
            Bruce.MusicGenresOffered["Rock"] = true;
            Bruce.MusicGenresOffered["Country"] = true;
            Bruce.MusicGenresOffered["Techno"] = true;
            Models.DJ Sara = new Models.DJ { VendorType = "DJ", DJEmail = "musicSara@gmail.com", DJPhone = "444-333-4567", LGBTQFriendly = true, DoesTravel = false, MusicGenresOffered = MusicGenres };
            Sara.MusicGenresOffered["Rock"] = true;
            Sara.MusicGenresOffered["Country"] = true;
            Sara.MusicGenresOffered["Techno"] = true;
            Models.DJ RadioSega = new Models.DJ { VendorType = "DJ", DJEmail = "RadioSega@gmail.com", DJPhone = "555-333-4567", LGBTQFriendly = true, DoesTravel = true, MusicGenresOffered = MusicGenres };
            RadioSega.MusicGenresOffered["Pop"] = true;
            RadioSega.MusicGenresOffered["R&B"] = true;
            RadioSega.MusicGenresOffered["Rap"] = true;
            RadioSega.MusicGenresOffered["Rock"] = true;
            RadioSega.MusicGenresOffered["Country"] = true;
            RadioSega.MusicGenresOffered["Techno"] = true;
            RadioSega.MusicGenresOffered["Metal"] = true;
            RadioSega.MusicGenresOffered["International"] = true;
            RadioSega.MusicGenresOffered["Other"] = true;
            //Photographers
            new Models.Photographer { VendorType = "Photographer", Name = "Burt Biggleson", PhotographerEmail = "Picman@gmail.com", PhotographerPhone = "111-444-4567", LGBTQFriendly = true, DoesTravel = true, DoesEditing = false, DoesVideo = false };
            new Models.Photographer { VendorType = "Photographer",Name = "Lesly Knope", PhotographerEmail = "knope@gmail.com", PhotographerPhone = "222-444-4567", LGBTQFriendly = true, DoesTravel = true, DoesEditing = true, DoesVideo = true };
            new Models.Photographer { VendorType = "Photographer",Name = "Linda Binderson", PhotographerEmail = "LindaB@gmail.com", PhotographerPhone = "333-444-4567", LGBTQFriendly = true, DoesTravel = true, DoesEditing = false, DoesVideo = true };
            new Models.Photographer { VendorType = "Photographer",Name = "Sam Hamson", PhotographerEmail = "bamSam@gmail.com", PhotographerPhone = "444-444-4567", LGBTQFriendly = false, DoesTravel = true, DoesEditing = false, DoesVideo = true };
            new Models.Photographer { VendorType = "Photographer",Name = "Ham Samson", PhotographerEmail = "perfect_ham@gmail.com", PhotographerPhone = "555-444-4567", LGBTQFriendly = true, DoesTravel = false, DoesEditing = false, DoesVideo = true };
            //Caterers
            Dictionary<string, bool> Cuisines = new Dictionary<string, bool>();
            Cuisines.Add("Indian", false);
            Cuisines.Add("Italian", false);
            Cuisines.Add("Chinese", false);
            Cuisines.Add("Mediterranean", false);
            Cuisines.Add("Mexican", false);
            Cuisines.Add("French", false);
            Cuisines.Add("American", false);
            Cuisines.Add("Other", false);
            Models.Caterer Best = new Models.Caterer { VendorType = "Caterer", Name = "Best Caterer", CatererEmail = "bestcaterer@gmail.com", CatererPhone = "414-111-0011", LGBTQfriendly = true, ServesVegan = true, FoodAllergyOptions = true, PerGuestEstimateLow = 50, PerGuestEstimateHigh = 100, CuisineTypes = Cuisines };
            Best.CuisineTypes["Indian"] = true;
            Best.CuisineTypes["Chinese"] = true;
            Best.CuisineTypes["Mediterranean"] = true;
            Models.Caterer AllFoods = new Models.Caterer { VendorType = "Caterer", Name = "AllFoods Caterer", CatererEmail = "allfoods@gmail.com", CatererPhone = "414-111-0022", LGBTQfriendly = true, ServesVegan = false, FoodAllergyOptions = true, PerGuestEstimateLow = 75, PerGuestEstimateHigh = 200, CuisineTypes = Cuisines };
            AllFoods.CuisineTypes["Indian"] = true;
            AllFoods.CuisineTypes["Italian"] = true;
            AllFoods.CuisineTypes["Chinese"] = true;
            AllFoods.CuisineTypes["Mediterranean"] = true;
            AllFoods.CuisineTypes["Mexican"] = true;
            AllFoods.CuisineTypes["French"] = true;
            AllFoods.CuisineTypes["American"] = true;
            AllFoods.CuisineTypes["Other"] = true;
            Models.Caterer GourmetFoods = new Models.Caterer { VendorType = "Caterer", Name = "GourmetFoods Caterer", CatererEmail = "gourmetfoods@gmail.com", CatererPhone = "414-111-0033", LGBTQfriendly = true, ServesVegan = true, FoodAllergyOptions = false, PerGuestEstimateLow = 90, PerGuestEstimateHigh = 250, CuisineTypes = Cuisines };
            GourmetFoods.CuisineTypes["Italian"] = true;
            GourmetFoods.CuisineTypes["Mexican"] = true;
            GourmetFoods.CuisineTypes["French"] = true;
            GourmetFoods.CuisineTypes["American"] = true;
            Models.Caterer MilwaukeeCaterers = new Models.Caterer { VendorType = "Caterer", Name = "Milwaukee Caterers", CatererEmail = "milwaukeecaterers@gmail.com", CatererPhone = "414-111-0044", LGBTQfriendly = false, ServesVegan = false, FoodAllergyOptions = true, PerGuestEstimateLow = 50, PerGuestEstimateHigh = 150, CuisineTypes = Cuisines };
            MilwaukeeCaterers.CuisineTypes["Other"] = true;
            MilwaukeeCaterers.CuisineTypes["American"] = true;
            MilwaukeeCaterers.CuisineTypes["Mexican"] = true;
            MilwaukeeCaterers.CuisineTypes["Chinese"] = true;
            Models.Caterer YourFavoriteCaterer = new Models.Caterer { VendorType = "Caterer",Name = "Your Favorite Caterer", CatererEmail = "yourfavoritecaterer@gmail.com", CatererPhone = "414-111-0055", LGBTQfriendly = true, ServesVegan = true, FoodAllergyOptions = false, PerGuestEstimateLow = 75, PerGuestEstimateHigh = 150, CuisineTypes = Cuisines };
            YourFavoriteCaterer.CuisineTypes["Indian"] = true;
            YourFavoriteCaterer.CuisineTypes["American"] = true;
            YourFavoriteCaterer.CuisineTypes["Mexican"] = true;
            YourFavoriteCaterer.CuisineTypes["French"] = true;
            YourFavoriteCaterer.CuisineTypes["Italian"] = true;
            //Venue
            Dictionary<string, bool> Religions = new Dictionary<string, bool>();
            Religions.Add("Judaism", false);
            Religions.Add("Sikhism", false);
            Religions.Add("Hinduism", false);
            Religions.Add("Islamic", false);
            Religions.Add("Non-denominational", false);
            Religions.Add("Catholicism", false);
            Religions.Add("Lutheranism", false);
            Religions.Add("Buddhism", false);
            Religions.Add("Others", false);
            Models.Venue Paradiso = new Models.Venue { VendorType = "Venue", Name = "Paradiso", VenueEmail = "paradiso@gmail.com", VenuePhone = "414 222 1111", LGBTQFriendly = true, KidFriendly = true, PetFriendly = false, HandicapAccessible = true, ReligionsServed = Religions, ServesCohabitants = true, Ceremony = true, Reception = true, ProvidesLodging = false, AllowsDecor = true, ThirdPartyCelebrant = true, ThirdPartyCatering = true, ThirdPartyDJ = true, Caters = false };
            Paradiso.ReligionsServed["Judaism"] = true;
            Paradiso.ReligionsServed["Sikhism"] = true;
            Paradiso.ReligionsServed["Hinduism"] = true;
            Paradiso.ReligionsServed["Islamic"] = true;
            Paradiso.ReligionsServed["Non-denominational"] = true;
            Paradiso.ReligionsServed["Catholism"] = true;
            Paradiso.ReligionsServed["Lutheranism"] = true;
            Paradiso.ReligionsServed["Buddism"] = true;
            Paradiso.ReligionsServed["Others"] = true;
            Models.Venue TajMahal = new Models.Venue { VendorType = "Venue", Name = "TajMahal", VenueEmail = "tajmahal@gmail.com", VenuePhone = "414 222 2222", LGBTQFriendly = true, KidFriendly = true, PetFriendly = true, HandicapAccessible = true, ReligionsServed = Religions, ServesCohabitants = true, Ceremony = false, Reception = true, ProvidesLodging = false, AllowsDecor = true, ThirdPartyCelebrant = true, ThirdPartyCatering = false, ThirdPartyDJ = true, Caters = true };
            TajMahal.ReligionsServed["Non-denominational"] = true;
            TajMahal.ReligionsServed["Catholism"] = true;
            TajMahal.ReligionsServed["Lutheranism"] = true;
            Models.Venue Hyatt = new Models.Venue { VendorType = "Venue", Name = "Hyatt", VenueEmail = "hyatt@gmail.com", VenuePhone = "414 222 3333", LGBTQFriendly = false, KidFriendly = false, PetFriendly = false, HandicapAccessible = true, ReligionsServed = Religions, ServesCohabitants = true, Ceremony = true, Reception = true, ProvidesLodging = false, AllowsDecor = true, ThirdPartyCelebrant = true, ThirdPartyCatering = true, ThirdPartyDJ = true, Caters = false };
            Hyatt.ReligionsServed["Judaism"] = true;
            Hyatt.ReligionsServed["Sikhism"] = true;
            Hyatt.ReligionsServed["Hinduism"] = true;
            Hyatt.ReligionsServed["Buddism"] = true;
            Hyatt.ReligionsServed["Others"] = true;
            Models.Venue Sofitel = new Models.Venue { VendorType = "Venue", Name = "Sofitel", VenueEmail = "sofitel@gmail.com", VenuePhone = "414 222 4444", LGBTQFriendly = true, KidFriendly = true, PetFriendly = false, HandicapAccessible = false, ReligionsServed = Religions, ServesCohabitants = false, Ceremony = true, Reception = true, ProvidesLodging = true, AllowsDecor = false, ThirdPartyCelebrant = false, ThirdPartyCatering = false, ThirdPartyDJ = false, Caters = true };
            Sofitel.ReligionsServed["Sikhism"] = true;
            Sofitel.ReligionsServed["Hinduism"] = true;
            Sofitel.ReligionsServed["Islamic"] = true;
            Sofitel.ReligionsServed["Catholism"] = true;
            Sofitel.ReligionsServed["Lutheranism"] = true;
            Sofitel.ReligionsServed["Buddism"] = true;
            Models.Venue Hilton = new Models.Venue { VendorType = "Venue", Name = "Hilton", VenueEmail = "hilton@gmail.com", VenuePhone = "414 222 5555", LGBTQFriendly = true, KidFriendly = false, PetFriendly = false, HandicapAccessible = true, ReligionsServed = Religions, ServesCohabitants = true, Ceremony = true, Reception = true, ProvidesLodging = false, AllowsDecor = true, ThirdPartyCelebrant = true, ThirdPartyCatering = true, ThirdPartyDJ = true, Caters = false };
            Hilton.ReligionsServed["Hinduism"] = true;
            Hilton.ReligionsServed["Islamic"] = true;
            Hilton.ReligionsServed["Catholism"] = true;
            Hilton.ReligionsServed["Lutheranism"] = true;
            Hilton.ReligionsServed["Buddism"] = true;
            Hilton.ReligionsServed["Others"] = true;

        }
    }
}
