namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Claims", "status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Claims", "status", c => c.String());
        }
    }
}
