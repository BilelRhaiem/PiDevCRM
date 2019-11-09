namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "IdAdmin", "dbo.Admins");
            DropIndex("dbo.Comments", new[] { "IdAdmin" });
            DropColumn("dbo.Comments", "IdAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "IdAdmin", c => c.Int());
            CreateIndex("dbo.Comments", "IdAdmin");
            AddForeignKey("dbo.Comments", "IdAdmin", "dbo.Admins", "IdAdmin");
        }
    }
}
