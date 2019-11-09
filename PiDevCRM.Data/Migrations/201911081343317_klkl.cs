namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class klkl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "TotalPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "TotalPrice");
            DropColumn("dbo.Carts", "Quantity");
        }
    }
}
