namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Availability", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Availability", c => c.Int(nullable: false));
        }
    }
}
