namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        IdAds = c.Int(nullable: false, identity: true),
                        IdPack = c.Int(),
                        IdProduct = c.Int(),
                        IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdAds)
                .ForeignKey("dbo.Packs", t => t.IdPack)
                .ForeignKey("dbo.Products", t => t.IdProduct)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdPack)
                .Index(t => t.IdProduct)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        IdPack = c.Int(nullable: false, identity: true),
                        IdProduct = c.Int(),
                        IdAd = c.Int(),
                        Ads_IdAds = c.Int(),
                    })
                .PrimaryKey(t => t.IdPack)
                .ForeignKey("dbo.Ads", t => t.IdAd)
                .ForeignKey("dbo.Products", t => t.IdProduct)
                .ForeignKey("dbo.Ads", t => t.Ads_IdAds)
                .Index(t => t.IdProduct)
                .Index(t => t.IdAd)
                .Index(t => t.Ads_IdAds);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        NameProduct = c.String(),
                        Price = c.Single(nullable: false),
                        ImageProduct = c.String(),
                        Availability = c.Boolean(nullable: false),
                        IdCategory = c.Int(nullable: false),
                        IdAd = c.Int(),
                        IdPack = c.Int(),
                        Pack_IdPack = c.Int(),
                        Ads_IdAds = c.Int(),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Ads", t => t.IdAd)
                .ForeignKey("dbo.Categories", t => t.IdCategory, cascadeDelete: true)
                .ForeignKey("dbo.Packs", t => t.IdPack)
                .ForeignKey("dbo.Packs", t => t.Pack_IdPack)
                .ForeignKey("dbo.Ads", t => t.Ads_IdAds)
                .Index(t => t.IdCategory)
                .Index(t => t.IdAd)
                .Index(t => t.IdPack)
                .Index(t => t.Pack_IdPack)
                .Index(t => t.Ads_IdAds);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdCategory)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
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
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Carts", t => t.IdCart)
                .Index(t => t.IdCart);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        IdCart = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdProduct = c.Int(),
                        IdPack = c.Int(),
                    })
                .PrimaryKey(t => t.IdCart)
                .ForeignKey("dbo.Packs", t => t.IdPack)
                .ForeignKey("dbo.Products", t => t.IdProduct)
                .Index(t => t.IdProduct)
                .Index(t => t.IdPack);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        IdAgent = c.Int(nullable: false, identity: true),
                        TypeAgent = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAgent);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        IdBill = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        IdCart = c.Int(),
                        purchaseDate = c.DateTime(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdBill)
                .ForeignKey("dbo.Carts", t => t.IdCart)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdCart);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        IdClaims = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        ClaimDate = c.DateTime(nullable: false),
                        TypeClaims = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.IdClaims)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IdComment = c.Int(nullable: false, identity: true),
                        IdPoste = c.Int(),
                        IdUser = c.Int(),
                        Content = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdComment)
                .ForeignKey("dbo.Postes", t => t.IdPoste)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdPoste)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Postes",
                c => new
                    {
                        IdPoste = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        Title = c.String(),
                        Content = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPoste)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        IdDiscount = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Pourcentage = c.Single(nullable: false),
                        IdProduct = c.Int(),
                    })
                .PrimaryKey(t => t.IdDiscount)
                .ForeignKey("dbo.Products", t => t.IdProduct)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Prospections",
                c => new
                    {
                        IdProspection = c.Int(nullable: false, identity: true),
                        TypeProspection = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.IdProspection);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        IdResource = c.Int(nullable: false, identity: true),
                        TypeResource = c.String(),
                        Availability = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdResource);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Ref_Stock = c.Int(nullable: false, identity: true),
                        idProduct = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Ref_Stock)
                .ForeignKey("dbo.Products", t => t.idProduct)
                .Index(t => t.idProduct);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        IdStore = c.Int(nullable: false, identity: true),
                        NameStore = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.IdStore);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "idProduct", "dbo.Products");
            DropForeignKey("dbo.Discounts", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Comments", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Comments", "IdPoste", "dbo.Postes");
            DropForeignKey("dbo.Postes", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Claims", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Bills", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Bills", "IdCart", "dbo.Carts");
            DropForeignKey("dbo.Ads", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Ads", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Ads", "IdPack", "dbo.Packs");
            DropForeignKey("dbo.Products", "Ads_IdAds", "dbo.Ads");
            DropForeignKey("dbo.Packs", "Ads_IdAds", "dbo.Ads");
            DropForeignKey("dbo.Packs", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Products", "Pack_IdPack", "dbo.Packs");
            DropForeignKey("dbo.Products", "IdPack", "dbo.Packs");
            DropForeignKey("dbo.Categories", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Users", "IdCart", "dbo.Carts");
            DropForeignKey("dbo.Carts", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Carts", "IdPack", "dbo.Packs");
            DropForeignKey("dbo.Products", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Products", "IdAd", "dbo.Ads");
            DropForeignKey("dbo.Packs", "IdAd", "dbo.Ads");
            DropIndex("dbo.Stocks", new[] { "idProduct" });
            DropIndex("dbo.Discounts", new[] { "IdProduct" });
            DropIndex("dbo.Postes", new[] { "IdUser" });
            DropIndex("dbo.Comments", new[] { "IdUser" });
            DropIndex("dbo.Comments", new[] { "IdPoste" });
            DropIndex("dbo.Claims", new[] { "IdUser" });
            DropIndex("dbo.Bills", new[] { "IdCart" });
            DropIndex("dbo.Bills", new[] { "IdUser" });
            DropIndex("dbo.Carts", new[] { "IdPack" });
            DropIndex("dbo.Carts", new[] { "IdProduct" });
            DropIndex("dbo.Users", new[] { "IdCart" });
            DropIndex("dbo.Categories", new[] { "IdUser" });
            DropIndex("dbo.Products", new[] { "Ads_IdAds" });
            DropIndex("dbo.Products", new[] { "Pack_IdPack" });
            DropIndex("dbo.Products", new[] { "IdPack" });
            DropIndex("dbo.Products", new[] { "IdAd" });
            DropIndex("dbo.Products", new[] { "IdCategory" });
            DropIndex("dbo.Packs", new[] { "Ads_IdAds" });
            DropIndex("dbo.Packs", new[] { "IdAd" });
            DropIndex("dbo.Packs", new[] { "IdProduct" });
            DropIndex("dbo.Ads", new[] { "IdUser" });
            DropIndex("dbo.Ads", new[] { "IdProduct" });
            DropIndex("dbo.Ads", new[] { "IdPack" });
            DropTable("dbo.Stores");
            DropTable("dbo.Stocks");
            DropTable("dbo.Resources");
            DropTable("dbo.Prospections");
            DropTable("dbo.Discounts");
            DropTable("dbo.Postes");
            DropTable("dbo.Comments");
            DropTable("dbo.Claims");
            DropTable("dbo.Bills");
            DropTable("dbo.Agents");
            DropTable("dbo.Carts");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Packs");
            DropTable("dbo.Ads");
        }
    }
}
