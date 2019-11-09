namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Discounts", "Pourcentage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Discounts", "Pourcentage", c => c.Single(nullable: false));
        }
    }
}
