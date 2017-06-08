namespace LovelyWaffles.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionID = c.Int(nullable: false, identity: true),
                        HeadDescription1 = c.String(),
                        Description1 = c.String(),
                        HeadDescription2 = c.String(),
                        Description2 = c.String(),
                        HeadDescription3 = c.String(),
                        Description3 = c.String(),
                        HeadDescription4 = c.String(),
                        Description4 = c.String(),
                    })
                .PrimaryKey(t => t.DescriptionID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImgCarouselTop = c.String(),
                        Pictures = c.String(),
                        Picture = c.String(),
                        ImgCarouselDown = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.PhotoGalleries",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.PhotoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhotoGalleries");
            DropTable("dbo.Images");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Contacts");
        }
    }
}
