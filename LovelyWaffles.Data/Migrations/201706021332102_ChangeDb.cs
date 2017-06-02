namespace LovelyWaffles.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImgCarouselTop = c.String(),
                        Pictures = c.String(),
                        ImgCarouselDown = c.String(),
                        IndexPage_IndexPageID = c.Int(),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.IndexPages", t => t.IndexPage_IndexPageID)
                .Index(t => t.IndexPage_IndexPageID);
            
            CreateTable(
                "dbo.IndexPages",
                c => new
                    {
                        IndexPageID = c.Int(nullable: false, identity: true),
                        Description1 = c.String(),
                        Description2 = c.String(),
                        Picture = c.String(),
                        Description3 = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IndexPageID);
            
            DropTable("dbo.PhotoCarousels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhotoCarousels",
                c => new
                    {
                        PhotoCarouselID = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        PhotoName = c.String(),
                    })
                .PrimaryKey(t => t.PhotoCarouselID);
            
            DropForeignKey("dbo.Images", "IndexPage_IndexPageID", "dbo.IndexPages");
            DropIndex("dbo.Images", new[] { "IndexPage_IndexPageID" });
            DropTable("dbo.IndexPages");
            DropTable("dbo.Images");
        }
    }
}
