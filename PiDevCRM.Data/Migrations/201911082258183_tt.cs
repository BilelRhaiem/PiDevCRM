namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Villes",
                c => new
                    {
                        VilleId = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        lon = c.Single(nullable: false),
                        lat = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.VilleId);
            
            AddColumn("dbo.Prospections", "VilleId", c => c.Int());
            CreateIndex("dbo.Prospections", "VilleId");
            AddForeignKey("dbo.Prospections", "VilleId", "dbo.Villes", "VilleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prospections", "VilleId", "dbo.Villes");
            DropIndex("dbo.Prospections", new[] { "VilleId" });
            DropColumn("dbo.Prospections", "VilleId");
            DropTable("dbo.Villes");
        }
    }
}
