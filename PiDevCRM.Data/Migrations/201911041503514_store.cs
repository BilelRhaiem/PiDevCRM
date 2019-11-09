namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Adresse", c => c.String());
            AddColumn("dbo.Stores", "Tel", c => c.String());
            AddColumn("dbo.Stores", "Email", c => c.String());
            AddColumn("dbo.Stores", "ouverture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "ouverture");
            DropColumn("dbo.Stores", "Email");
            DropColumn("dbo.Stores", "Tel");
            DropColumn("dbo.Stores", "Adresse");
        }
    }
}
