namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricepack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Packs", "PackPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Packs", "PackPrice");
        }
    }
}
