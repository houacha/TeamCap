namespace WeddingPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reseeding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Couples", "WeddingId", "dbo.WeddingPackages");
            DropForeignKey("dbo.Venues", "CatererId", "dbo.Caterers");
            DropIndex("dbo.Couples", new[] { "WeddingId" });
            DropIndex("dbo.Venues", new[] { "CatererId" });
            AddColumn("dbo.Caterers", "FoodIndian", c => c.Boolean(nullable: false));
            AddColumn("dbo.Caterers", "FoodItalian", c => c.Boolean(nullable: false));
            AddColumn("dbo.Caterers", "FoodChinese", c => c.Boolean(nullable: false));
            AddColumn("dbo.Caterers", "FoodMediterranean", c => c.Boolean(nullable: false));
            AddColumn("dbo.Caterers", "FoodMexican", c => c.Boolean(nullable: false));
            AddColumn("dbo.Caterers", "FoodFrench", c => c.Boolean(nullable: false));
            AddColumn("dbo.Caterers", "FoodAmerican", c => c.Boolean(nullable: false));
            AddColumn("dbo.Caterers", "FoodOther", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "Judaism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "Sikhism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "Hinduism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "Islamic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "NonDenominational", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "Catholicism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "Lutheranism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "Buddhism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Celebrants", "ReligionOther", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenrePop", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreRB", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreRap", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreRock", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreCountry", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreDance", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreTechno", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreMetal", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreInternational", c => c.Boolean(nullable: false));
            AddColumn("dbo.DJs", "GenreOther", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Judaism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Sikhism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Hinduism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Islamic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "NonDenominational", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Catholicism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Lutheranism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Buddhism", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "ReligionOther", c => c.Boolean(nullable: false));
            AddColumn("dbo.Venues", "Caterers", c => c.Boolean(nullable: false));
            DropColumn("dbo.Couples", "WeddingId");
            DropColumn("dbo.Venues", "Caters");
            DropColumn("dbo.Venues", "CatererId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venues", "CatererId", c => c.Int(nullable: false));
            AddColumn("dbo.Venues", "Caters", c => c.Boolean(nullable: false));
            AddColumn("dbo.Couples", "WeddingId", c => c.Int(nullable: false));
            DropColumn("dbo.Venues", "Caterers");
            DropColumn("dbo.Venues", "ReligionOther");
            DropColumn("dbo.Venues", "Buddhism");
            DropColumn("dbo.Venues", "Lutheranism");
            DropColumn("dbo.Venues", "Catholicism");
            DropColumn("dbo.Venues", "NonDenominational");
            DropColumn("dbo.Venues", "Islamic");
            DropColumn("dbo.Venues", "Hinduism");
            DropColumn("dbo.Venues", "Sikhism");
            DropColumn("dbo.Venues", "Judaism");
            DropColumn("dbo.DJs", "GenreOther");
            DropColumn("dbo.DJs", "GenreInternational");
            DropColumn("dbo.DJs", "GenreMetal");
            DropColumn("dbo.DJs", "GenreTechno");
            DropColumn("dbo.DJs", "GenreDance");
            DropColumn("dbo.DJs", "GenreCountry");
            DropColumn("dbo.DJs", "GenreRock");
            DropColumn("dbo.DJs", "GenreRap");
            DropColumn("dbo.DJs", "GenreRB");
            DropColumn("dbo.DJs", "GenrePop");
            DropColumn("dbo.Celebrants", "ReligionOther");
            DropColumn("dbo.Celebrants", "Buddhism");
            DropColumn("dbo.Celebrants", "Lutheranism");
            DropColumn("dbo.Celebrants", "Catholicism");
            DropColumn("dbo.Celebrants", "NonDenominational");
            DropColumn("dbo.Celebrants", "Islamic");
            DropColumn("dbo.Celebrants", "Hinduism");
            DropColumn("dbo.Celebrants", "Sikhism");
            DropColumn("dbo.Celebrants", "Judaism");
            DropColumn("dbo.Caterers", "FoodOther");
            DropColumn("dbo.Caterers", "FoodAmerican");
            DropColumn("dbo.Caterers", "FoodFrench");
            DropColumn("dbo.Caterers", "FoodMexican");
            DropColumn("dbo.Caterers", "FoodMediterranean");
            DropColumn("dbo.Caterers", "FoodChinese");
            DropColumn("dbo.Caterers", "FoodItalian");
            DropColumn("dbo.Caterers", "FoodIndian");
            CreateIndex("dbo.Venues", "CatererId");
            CreateIndex("dbo.Couples", "WeddingId");
            AddForeignKey("dbo.Venues", "CatererId", "dbo.Caterers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Couples", "WeddingId", "dbo.WeddingPackages", "WeddingId", cascadeDelete: true);
        }
    }
}
