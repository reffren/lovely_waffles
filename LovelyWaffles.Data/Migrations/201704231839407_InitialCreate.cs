namespace LovelyWaffles.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhotoCarousels");
        }
    }
}
