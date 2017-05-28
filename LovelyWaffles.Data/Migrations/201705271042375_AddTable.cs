namespace LovelyWaffles.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
