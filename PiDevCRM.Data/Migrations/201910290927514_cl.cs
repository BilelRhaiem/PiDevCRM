namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "IdCart", "dbo.Carts");
            DropForeignKey("dbo.Categories", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Ads", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Bills", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Claims", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Postes", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Comments", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Products", "IdCategory", "dbo.Categories");
            DropIndex("dbo.Ads", new[] { "IdUser" });
            DropIndex("dbo.Products", new[] { "IdCategory" });
            DropIndex("dbo.Categories", new[] { "IdUser" });
            DropIndex("dbo.Users", new[] { "IdCart" });
            DropIndex("dbo.Bills", new[] { "IdUser" });
            DropIndex("dbo.Claims", new[] { "IdUser" });
            DropIndex("dbo.Comments", new[] { "IdUser" });
            DropIndex("dbo.Postes", new[] { "IdUser" });
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        IdAdmin = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Login = c.String(),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAdmin);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        ClientType = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdClient);
            
            AddColumn("dbo.Ads", "IdClient", c => c.Int());
            AddColumn("dbo.Products", "IdDiscount", c => c.Int());
            AddColumn("dbo.Products", "IdStock", c => c.Int());
            AddColumn("dbo.Products", "Discount_IdDiscount", c => c.Int());
            AddColumn("dbo.Products", "Stock_Ref_Stock", c => c.Int());
            AddColumn("dbo.Categories", "IdClient", c => c.Int());
            AddColumn("dbo.Carts", "IdClient", c => c.Int());
            AddColumn("dbo.Agents", "IdProspection", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "IdClient", c => c.Int());
            AddColumn("dbo.Claims", "IdClient", c => c.Int());
            AddColumn("dbo.Claims", "Answer", c => c.String());
            AddColumn("dbo.Comments", "IdClient", c => c.Int());
            AddColumn("dbo.Comments", "IdAdmin", c => c.Int());
            AddColumn("dbo.Postes", "IdClient", c => c.Int());
            AddColumn("dbo.Resources", "IdProspection", c => c.Int());
            AddColumn("dbo.Stocks", "IdStore", c => c.Int());
            AlterColumn("dbo.Products", "IdCategory", c => c.Int());
            AlterColumn("dbo.Agents", "TypeAgent", c => c.Int(nullable: false));
            AlterColumn("dbo.Claims", "typeClaims", c => c.Int(nullable: false));
            CreateIndex("dbo.Ads", "IdClient");
            CreateIndex("dbo.Bills", "IdClient");
            CreateIndex("dbo.Carts", "IdClient");
            CreateIndex("dbo.Products", "IdCategory");
            CreateIndex("dbo.Products", "IdDiscount");
            CreateIndex("dbo.Products", "IdStock");
            CreateIndex("dbo.Products", "Discount_IdDiscount");
            CreateIndex("dbo.Products", "Stock_Ref_Stock");
            CreateIndex("dbo.Categories", "IdClient");
            CreateIndex("dbo.Stocks", "IdStore");
            CreateIndex("dbo.Claims", "IdClient");
            CreateIndex("dbo.Agents", "IdProspection");
            CreateIndex("dbo.Resources", "IdProspection");
            CreateIndex("dbo.Comments", "IdAdmin");
            CreateIndex("dbo.Postes", "IdClient");
            AddForeignKey("dbo.Carts", "IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.Categories", "IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.Products", "Discount_IdDiscount", "dbo.Discounts", "IdDiscount");
            AddForeignKey("dbo.Products", "IdDiscount", "dbo.Discounts", "IdDiscount");
            AddForeignKey("dbo.Products", "Stock_Ref_Stock", "dbo.Stocks", "Ref_Stock");
            AddForeignKey("dbo.Stocks", "IdStore", "dbo.Stores", "IdStore");
            AddForeignKey("dbo.Products", "IdStock", "dbo.Stocks", "Ref_Stock");
            AddForeignKey("dbo.Bills", "IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.Claims", "IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.Ads", "IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.Agents", "IdProspection", "dbo.Prospections", "IdProspection", cascadeDelete: true);
            AddForeignKey("dbo.Resources", "IdProspection", "dbo.Prospections", "IdProspection");
            AddForeignKey("dbo.Comments", "IdAdmin", "dbo.Admins", "IdAdmin");
            AddForeignKey("dbo.Postes", "IdClient", "dbo.Clients", "IdClient");
            AddForeignKey("dbo.Products", "IdCategory", "dbo.Categories", "IdCategory");
            DropColumn("dbo.Ads", "IdUser");
            DropColumn("dbo.Categories", "IdUser");
            DropColumn("dbo.Carts", "IdUser");
            DropColumn("dbo.Bills", "IdUser");
            DropColumn("dbo.Claims", "IdUser");
            DropColumn("dbo.Comments", "IdUser");
            DropColumn("dbo.Postes", "IdUser");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Role = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Image = c.String(),
                        IdCart = c.Int(),
                    })
                .PrimaryKey(t => t.idUser);
            
            AddColumn("dbo.Postes", "IdUser", c => c.Int());
            AddColumn("dbo.Comments", "IdUser", c => c.Int());
            AddColumn("dbo.Claims", "IdUser", c => c.Int());
            AddColumn("dbo.Bills", "IdUser", c => c.Int());
            AddColumn("dbo.Carts", "IdUser", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "IdUser", c => c.Int());
            AddColumn("dbo.Ads", "IdUser", c => c.Int());
            DropForeignKey("dbo.Products", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Postes", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Comments", "IdAdmin", "dbo.Admins");
            DropForeignKey("dbo.Resources", "IdProspection", "dbo.Prospections");
            DropForeignKey("dbo.Agents", "IdProspection", "dbo.Prospections");
            DropForeignKey("dbo.Ads", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Claims", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Bills", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Products", "IdStock", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "IdStore", "dbo.Stores");
            DropForeignKey("dbo.Products", "Stock_Ref_Stock", "dbo.Stocks");
            DropForeignKey("dbo.Products", "IdDiscount", "dbo.Discounts");
            DropForeignKey("dbo.Products", "Discount_IdDiscount", "dbo.Discounts");
            DropForeignKey("dbo.Categories", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Carts", "IdClient", "dbo.Clients");
            DropIndex("dbo.Postes", new[] { "IdClient" });
            DropIndex("dbo.Comments", new[] { "IdAdmin" });
            DropIndex("dbo.Resources", new[] { "IdProspection" });
            DropIndex("dbo.Agents", new[] { "IdProspection" });
            DropIndex("dbo.Claims", new[] { "IdClient" });
            DropIndex("dbo.Stocks", new[] { "IdStore" });
            DropIndex("dbo.Categories", new[] { "IdClient" });
            DropIndex("dbo.Products", new[] { "Stock_Ref_Stock" });
            DropIndex("dbo.Products", new[] { "Discount_IdDiscount" });
            DropIndex("dbo.Products", new[] { "IdStock" });
            DropIndex("dbo.Products", new[] { "IdDiscount" });
            DropIndex("dbo.Products", new[] { "IdCategory" });
            DropIndex("dbo.Carts", new[] { "IdClient" });
            DropIndex("dbo.Bills", new[] { "IdClient" });
            DropIndex("dbo.Ads", new[] { "IdClient" });
            AlterColumn("dbo.Claims", "typeClaims", c => c.String());
            AlterColumn("dbo.Agents", "TypeAgent", c => c.String());
            AlterColumn("dbo.Products", "IdCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "IdStore");
            DropColumn("dbo.Resources", "IdProspection");
            DropColumn("dbo.Postes", "IdClient");
            DropColumn("dbo.Comments", "IdAdmin");
            DropColumn("dbo.Comments", "IdClient");
            DropColumn("dbo.Claims", "Answer");
            DropColumn("dbo.Claims", "IdClient");
            DropColumn("dbo.Bills", "IdClient");
            DropColumn("dbo.Agents", "IdProspection");
            DropColumn("dbo.Carts", "IdClient");
            DropColumn("dbo.Categories", "IdClient");
            DropColumn("dbo.Products", "Stock_Ref_Stock");
            DropColumn("dbo.Products", "Discount_IdDiscount");
            DropColumn("dbo.Products", "IdStock");
            DropColumn("dbo.Products", "IdDiscount");
            DropColumn("dbo.Ads", "IdClient");
            DropTable("dbo.Clients");
            DropTable("dbo.Admins");
            CreateIndex("dbo.Postes", "IdUser");
            CreateIndex("dbo.Comments", "IdUser");
            CreateIndex("dbo.Claims", "IdUser");
            CreateIndex("dbo.Bills", "IdUser");
            CreateIndex("dbo.Users", "IdCart");
            CreateIndex("dbo.Categories", "IdUser");
            CreateIndex("dbo.Products", "IdCategory");
            CreateIndex("dbo.Ads", "IdUser");
            AddForeignKey("dbo.Products", "IdCategory", "dbo.Categories", "IdCategory", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "IdUser", "dbo.Users", "idUser");
            AddForeignKey("dbo.Postes", "IdUser", "dbo.Users", "idUser");
            AddForeignKey("dbo.Claims", "IdUser", "dbo.Users", "idUser");
            AddForeignKey("dbo.Bills", "IdUser", "dbo.Users", "idUser");
            AddForeignKey("dbo.Ads", "IdUser", "dbo.Users", "idUser");
            AddForeignKey("dbo.Categories", "IdUser", "dbo.Users", "idUser");
            AddForeignKey("dbo.Users", "IdCart", "dbo.Carts", "IdCart");
        }
    }
}
