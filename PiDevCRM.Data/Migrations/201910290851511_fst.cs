namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fst : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agents", "IdProspection", "dbo.Prospections");
            DropIndex("dbo.Agents", new[] { "IdProspection" });
            AlterColumn("dbo.Agents", "IdProspection", c => c.Int());
            CreateIndex("dbo.Agents", "IdProspection");
            AddForeignKey("dbo.Agents", "IdProspection", "dbo.Prospections", "IdProspection");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agents", "IdProspection", "dbo.Prospections");
            DropIndex("dbo.Agents", new[] { "IdProspection" });
            AlterColumn("dbo.Agents", "IdProspection", c => c.Int(nullable: false));
            CreateIndex("dbo.Agents", "IdProspection");
            AddForeignKey("dbo.Agents", "IdProspection", "dbo.Prospections", "IdProspection", cascadeDelete: true);
        }
    }
}
