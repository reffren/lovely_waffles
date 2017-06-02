namespace LovelyWaffles.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndexPages", "HeadDescription1", c => c.String());
            AddColumn("dbo.IndexPages", "HeadDescription2", c => c.String());
            AddColumn("dbo.IndexPages", "HeadDescription3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndexPages", "HeadDescription3");
            DropColumn("dbo.IndexPages", "HeadDescription2");
            DropColumn("dbo.IndexPages", "HeadDescription1");
        }
    }
}
