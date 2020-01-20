namespace WeddingPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvenuetotable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VenueEmail = c.String(),
                        VenuePhone = c.String(),
                        LGBTQFriendly = c.Boolean(nullable: false),
                        KidFriendly = c.Boolean(nullable: false),
                        PetFriendly = c.Boolean(nullable: false),
                        HandicapAccessible = c.Boolean(nullable: false),
                        ReligionsServed = c.String(),
                        ServesCohabitants = c.Boolean(nullable: false),
                        Ceremony = c.Boolean(nullable: false),
                        Reception = c.Boolean(nullable: false),
                        ProvidesLodging = c.Boolean(nullable: false),
                        AllowsDecor = c.Boolean(nullable: false),
                        ThirdPartyCelebrant = c.Boolean(nullable: false),
                        ThirdPartyCatering = c.Boolean(nullable: false),
                        ThirdPartyDJ = c.Boolean(nullable: false),
                        Caters = c.Boolean(nullable: false),
                        CatererId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendorId)
                .ForeignKey("dbo.Caterers", t => t.CatererId, cascadeDelete: true)
                .Index(t => t.CatererId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venues", "CatererId", "dbo.Caterers");
            DropIndex("dbo.Venues", new[] { "CatererId" });
            DropTable("dbo.Venues");
        }
    }
}
