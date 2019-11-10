namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class packdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packs", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Packs", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packs", "EndDate");
            DropColumn("dbo.Packs", "StartDate");
        }
    }
}
