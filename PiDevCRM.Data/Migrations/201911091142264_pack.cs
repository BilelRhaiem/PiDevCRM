namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packs", "PackPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Packs", "PackImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packs", "PackImage");
            DropColumn("dbo.Packs", "PackPrice");
        }
    }
}
