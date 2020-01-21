namespace WeddingPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class venue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Caterers", "VendorType", c => c.String());
            AddColumn("dbo.Caterers", "Street", c => c.String());
            AddColumn("dbo.Caterers", "City", c => c.String());
            AddColumn("dbo.Caterers", "Zip", c => c.String());
            AddColumn("dbo.Caterers", "State", c => c.String());
            AddColumn("dbo.Caterers", "Country", c => c.String());
            AddColumn("dbo.Celebrants", "VendorType", c => c.String());
            AddColumn("dbo.Celebrants", "Street", c => c.String());
            AddColumn("dbo.Celebrants", "City", c => c.String());
            AddColumn("dbo.Celebrants", "Zip", c => c.String());
            AddColumn("dbo.Celebrants", "State", c => c.String());
            AddColumn("dbo.Celebrants", "Country", c => c.String());
            AddColumn("dbo.DJs", "VendorType", c => c.String());
            AddColumn("dbo.DJs", "Street", c => c.String());
            AddColumn("dbo.DJs", "City", c => c.String());
            AddColumn("dbo.DJs", "Zip", c => c.String());
            AddColumn("dbo.DJs", "State", c => c.String());
            AddColumn("dbo.DJs", "Country", c => c.String());
            AddColumn("dbo.Photographers", "VendorType", c => c.String());
            AddColumn("dbo.Photographers", "Street", c => c.String());
            AddColumn("dbo.Photographers", "City", c => c.String());
            AddColumn("dbo.Photographers", "Zip", c => c.String());
            AddColumn("dbo.Photographers", "State", c => c.String());
            AddColumn("dbo.Photographers", "Country", c => c.String());
            AddColumn("dbo.Photographers", "LGBTQFriendly", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "VendorType", c => c.String());
            AddColumn("dbo.Venues", "Street", c => c.String());
            AddColumn("dbo.Venues", "City", c => c.String());
            AddColumn("dbo.Venues", "Zip", c => c.String());
            AddColumn("dbo.Venues", "State", c => c.String());
            AddColumn("dbo.Venues", "Country", c => c.String());
            AlterColumn("dbo.Caterers", "FoodAllergyOptions", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Celebrants", "CelebrantPhone", c => c.String());
            AlterColumn("dbo.Photographers", "PhotographerPhone", c => c.String());
            DropColumn("dbo.Caterers", "CuisineTypes");
            DropColumn("dbo.Celebrants", "ReligionsServed");
            DropColumn("dbo.WeddingPackages", "CuisineTypes");
            DropColumn("dbo.WeddingPackages", "MusicGenres");
            DropColumn("dbo.WeddingPackages", "ReligiousService");
            DropColumn("dbo.DJs", "MusicGenresOffered");
            DropColumn("dbo.Photographers", "ServesLGBTQ");
            DropColumn("dbo.Venues", "ReligionsServed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venues", "ReligionsServed", c => c.String());
            AddColumn("dbo.Photographers", "ServesLGBTQ", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "MusicGenresOffered", c => c.Boolean(nullable: false));
            AddColumn("dbo.WeddingPackages", "ReligiousService", c => c.String());
            AddColumn("dbo.WeddingPackages", "MusicGenres", c => c.Boolean(nullable: false));
            AddColumn("dbo.WeddingPackages", "CuisineTypes", c => c.String());
            AddColumn("dbo.Celebrants", "ReligionsServed", c => c.String());
            AddColumn("dbo.Caterers", "CuisineTypes", c => c.String());
            AlterColumn("dbo.Photographers", "PhotographerPhone", c => c.Int(nullable: false));
            AlterColumn("dbo.Celebrants", "CelebrantPhone", c => c.Int(nullable: false));
            AlterColumn("dbo.Caterers", "FoodAllergyOptions", c => c.String());
            DropColumn("dbo.Venues", "Country");
            DropColumn("dbo.Venues", "State");
            DropColumn("dbo.Venues", "Zip");
            DropColumn("dbo.Venues", "City");
            DropColumn("dbo.Venues", "Street");
            DropColumn("dbo.Venues", "VendorType");
            DropColumn("dbo.Photographers", "LGBTQFriendly");
            DropColumn("dbo.Photographers", "Country");
            DropColumn("dbo.Photographers", "State");
            DropColumn("dbo.Photographers", "Zip");
            DropColumn("dbo.Photographers", "City");
            DropColumn("dbo.Photographers", "Street");
            DropColumn("dbo.Photographers", "VendorType");
            DropColumn("dbo.DJs", "Country");
            DropColumn("dbo.DJs", "State");
            DropColumn("dbo.DJs", "Zip");
            DropColumn("dbo.DJs", "City");
            DropColumn("dbo.DJs", "Street");
            DropColumn("dbo.DJs", "VendorType");
            DropColumn("dbo.Celebrants", "Country");
            DropColumn("dbo.Celebrants", "State");
            DropColumn("dbo.Celebrants", "Zip");
            DropColumn("dbo.Celebrants", "City");
            DropColumn("dbo.Celebrants", "Street");
            DropColumn("dbo.Celebrants", "VendorType");
            DropColumn("dbo.Caterers", "Country");
            DropColumn("dbo.Caterers", "State");
            DropColumn("dbo.Caterers", "Zip");
            DropColumn("dbo.Caterers", "City");
            DropColumn("dbo.Caterers", "Street");
            DropColumn("dbo.Caterers", "VendorType");
        }
    }
}
