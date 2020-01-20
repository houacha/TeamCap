namespace WeddingPlannerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontrollers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Couples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoupleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
            DropTable("dbo.Couples");
        }
    }
}
