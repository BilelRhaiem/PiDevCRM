namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floatprice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Packs", "PackPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Packs", "PackPrice", c => c.Int(nullable: false));
        }
    }
}
