namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "stockname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "stockname");
        }
    }
}
