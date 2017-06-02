namespace LovelyWaffles.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndexPages", "HeadDescription4", c => c.String());
            AddColumn("dbo.IndexPages", "Description4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndexPages", "Description4");
            DropColumn("dbo.IndexPages", "HeadDescription4");
        }
    }
}
