namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claims", "statustype", c => c.Int(nullable: false));
            DropColumn("dbo.Claims", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claims", "status", c => c.Int(nullable: false));
            DropColumn("dbo.Claims", "statustype");
        }
    }
}
