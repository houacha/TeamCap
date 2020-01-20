namespace WeddingPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changednameofvenueprop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caterers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CatererEmail = c.String(),
                        CatererPhone = c.String(),
                        LGBTQfriendly = c.Boolean(nullable: false),
                        CuisineTypes = c.String(),
                        ServesVegan = c.Boolean(nullable: false),
                        FoodAllergyOptions = c.String(),
                        PerGuestEstimateLow = c.Double(nullable: false),
                        PerGuestEstimateHigh = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Celebrants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CelebrantEmail = c.String(),
                        CelebrantPhone = c.Int(nullable: false),
                        DoesTravel = c.Boolean(nullable: false),
                        ReligionsServed = c.String(),
                        ServicesCohabitants = c.Boolean(nullable: false),
                        LGBTQFriendly = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Couples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Partner1FirstName = c.String(),
                        Partner1LastName = c.String(),
                        Partner2FirstName = c.String(),
                        Partner2LastName = c.String(),
                        CoupleStreetAddress = c.String(),
                        City = c.String(),
                        Zipcode = c.Int(nullable: false),
                        WeddingBudget = c.Double(nullable: false),
                        EstimatedTotal = c.Double(nullable: false),
                        CoupleEmail = c.String(),
                        CouplePhone = c.String(),
                        WeddingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeddingPackages", t => t.WeddingId, cascadeDelete: true)
                .Index(t => t.WeddingId);
            
            CreateTable(
                "dbo.WeddingPackages",
                c => new
                    {
                        WeddingId = c.Int(nullable: false, identity: true),
                        ThirdPartyVendors = c.Boolean(nullable: false),
                        LGBTQFriendly = c.Boolean(nullable: false),
                        ServesCohabitants = c.Boolean(nullable: false),
                        KidFriendly = c.Boolean(nullable: false),
                        PetFriendly = c.Boolean(nullable: false),
                        WheelchairAccessible = c.Boolean(nullable: false),
                        FoodAllergyOptions = c.Boolean(nullable: false),
                        Vegan = c.Boolean(nullable: false),
                        CuisineTypes = c.String(),
                        MusicGenres = c.Boolean(nullable: false),
                        ReligiousService = c.String(),
                    })
                .PrimaryKey(t => t.WeddingId);
            
            CreateTable(
                "dbo.DJs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DJEmail = c.String(),
                        DJPhone = c.String(),
                        MusicGenresOffered = c.Boolean(nullable: false),
                        DoesTravel = c.Boolean(nullable: false),
                        LGBTQFriendly = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photographers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhotographerEmail = c.String(),
                        PhotographerPhone = c.Int(nullable: false),
                        DoesVideo = c.Boolean(nullable: false),
                        DoesEditing = c.Boolean(nullable: false),
                        ServesLGBTQ = c.Boolean(nullable: false),
                        DoesTravel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Couples", "WeddingId", "dbo.WeddingPackages");
            DropIndex("dbo.Couples", new[] { "WeddingId" });
            DropTable("dbo.Photographers");
            DropTable("dbo.DJs");
            DropTable("dbo.WeddingPackages");
            DropTable("dbo.Couples");
            DropTable("dbo.Celebrants");
            DropTable("dbo.Caterers");
        }
    }
}
