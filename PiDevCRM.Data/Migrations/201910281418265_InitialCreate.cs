namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Ads",
                c => new
                    {
                        IdAds = c.Int(nullable: false, identity: true),
                        IdPack = c.Int(),
                        IdProduct = c.Int(),
                        IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdAds)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .ForeignKey("dbo.Packs", t => t.IdPack)
                .ForeignKey("dbo.Products", t => t.IdProduct)
                .Index(t => t.IdPack)
                .Index(t => t.IdProduct)
                .Index(t => t.IdClient);
            
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
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        IdBill = c.Int(nullable: false, identity: true),
                        IdClient = c.Int(),
                        IdCart = c.Int(),
                        purchaseDate = c.DateTime(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdBill)
                .ForeignKey("dbo.Carts", t => t.IdCart)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .Index(t => t.IdClient)
                .Index(t => t.IdCart);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        IdCart = c.Int(nullable: false, identity: true),
                        IdClient = c.Int(),
                        IdProduct = c.Int(),
                        IdPack = c.Int(),
                    })
                .PrimaryKey(t => t.IdCart)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .ForeignKey("dbo.Packs", t => t.IdPack)
                .ForeignKey("dbo.Products", t => t.IdProduct)
                .Index(t => t.IdClient)
                .Index(t => t.IdProduct)
                .Index(t => t.IdPack);
            
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
                        IdCategory = c.Int(),
                        IdDiscount = c.Int(),
                        IdStock = c.Int(),
                        IdAd = c.Int(),
                        IdPack = c.Int(),
                        Discount_IdDiscount = c.Int(),
                        Stock_Ref_Stock = c.Int(),
                        Pack_IdPack = c.Int(),
                        Ads_IdAds = c.Int(),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Ads", t => t.IdAd)
                .ForeignKey("dbo.Categories", t => t.IdCategory)
                .ForeignKey("dbo.Discounts", t => t.Discount_IdDiscount)
                .ForeignKey("dbo.Discounts", t => t.IdDiscount)
                .ForeignKey("dbo.Packs", t => t.IdPack)
                .ForeignKey("dbo.Stocks", t => t.Stock_Ref_Stock)
                .ForeignKey("dbo.Stocks", t => t.IdStock)
                .ForeignKey("dbo.Packs", t => t.Pack_IdPack)
                .ForeignKey("dbo.Ads", t => t.Ads_IdAds)
                .Index(t => t.IdCategory)
                .Index(t => t.IdDiscount)
                .Index(t => t.IdStock)
                .Index(t => t.IdAd)
                .Index(t => t.IdPack)
                .Index(t => t.Discount_IdDiscount)
                .Index(t => t.Stock_Ref_Stock)
                .Index(t => t.Pack_IdPack)
                .Index(t => t.Ads_IdAds);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        IdClient = c.Int(),
                    })
                .PrimaryKey(t => t.IdCategory)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .Index(t => t.IdClient);
            
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
                "dbo.Stocks",
                c => new
                    {
                        Ref_Stock = c.Int(nullable: false, identity: true),
                        idProduct = c.Int(),
                        IdStore = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Ref_Stock)
                .ForeignKey("dbo.Products", t => t.idProduct)
                .ForeignKey("dbo.Stores", t => t.IdStore)
                .Index(t => t.idProduct)
                .Index(t => t.IdStore);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        IdStore = c.Int(nullable: false, identity: true),
                        NameStore = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.IdStore);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        IdClaims = c.Int(nullable: false, identity: true),
                        IdClient = c.Int(),
                        ClaimDate = c.DateTime(nullable: false),
                        TypeClaims = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.IdClaims)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .Index(t => t.IdClient);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        IdAgent = c.Int(nullable: false, identity: true),
                        IdProspection = c.Int(nullable: false),
                        TypeAgent = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAgent)
                .ForeignKey("dbo.Prospections", t => t.IdProspection, cascadeDelete: true)
                .Index(t => t.IdProspection);
            
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
                        IdProspection = c.Int(),
                        TypeResource = c.String(),
                        Availability = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdResource)
                .ForeignKey("dbo.Prospections", t => t.IdProspection)
                .Index(t => t.IdProspection);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IdComment = c.Int(nullable: false, identity: true),
                        IdPoste = c.Int(),
                        IdClient = c.Int(),
                        IdAdmin = c.Int(),
                        Content = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdComment)
                .ForeignKey("dbo.Admins", t => t.IdAdmin)
                .ForeignKey("dbo.Postes", t => t.IdPoste)
                .Index(t => t.IdPoste)
                .Index(t => t.IdAdmin);
            
            CreateTable(
                "dbo.Postes",
                c => new
                    {
                        IdPoste = c.Int(nullable: false, identity: true),
                        IdClient = c.Int(),
                        Title = c.String(),
                        Content = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPoste)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .Index(t => t.IdClient);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "IdPoste", "dbo.Postes");
            DropForeignKey("dbo.Postes", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Comments", "IdAdmin", "dbo.Admins");
            DropForeignKey("dbo.Resources", "IdProspection", "dbo.Prospections");
            DropForeignKey("dbo.Agents", "IdProspection", "dbo.Prospections");
            DropForeignKey("dbo.Ads", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Ads", "IdPack", "dbo.Packs");
            DropForeignKey("dbo.Products", "Ads_IdAds", "dbo.Ads");
            DropForeignKey("dbo.Packs", "Ads_IdAds", "dbo.Ads");
            DropForeignKey("dbo.Ads", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Claims", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Bills", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Carts", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Carts", "IdPack", "dbo.Packs");
            DropForeignKey("dbo.Packs", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Products", "Pack_IdPack", "dbo.Packs");
            DropForeignKey("dbo.Products", "IdStock", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "IdStore", "dbo.Stores");
            DropForeignKey("dbo.Stocks", "idProduct", "dbo.Products");
            DropForeignKey("dbo.Products", "Stock_Ref_Stock", "dbo.Stocks");
            DropForeignKey("dbo.Products", "IdPack", "dbo.Packs");
            DropForeignKey("dbo.Products", "IdDiscount", "dbo.Discounts");
            DropForeignKey("dbo.Discounts", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.Products", "Discount_IdDiscount", "dbo.Discounts");
            DropForeignKey("dbo.Products", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Categories", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Products", "IdAd", "dbo.Ads");
            DropForeignKey("dbo.Packs", "IdAd", "dbo.Ads");
            DropForeignKey("dbo.Bills", "IdCart", "dbo.Carts");
            DropForeignKey("dbo.Carts", "IdClient", "dbo.Clients");
            DropIndex("dbo.Postes", new[] { "IdClient" });
            DropIndex("dbo.Comments", new[] { "IdAdmin" });
            DropIndex("dbo.Comments", new[] { "IdPoste" });
            DropIndex("dbo.Resources", new[] { "IdProspection" });
            DropIndex("dbo.Agents", new[] { "IdProspection" });
            DropIndex("dbo.Claims", new[] { "IdClient" });
            DropIndex("dbo.Stocks", new[] { "IdStore" });
            DropIndex("dbo.Stocks", new[] { "idProduct" });
            DropIndex("dbo.Discounts", new[] { "IdProduct" });
            DropIndex("dbo.Categories", new[] { "IdClient" });
            DropIndex("dbo.Products", new[] { "Ads_IdAds" });
            DropIndex("dbo.Products", new[] { "Pack_IdPack" });
            DropIndex("dbo.Products", new[] { "Stock_Ref_Stock" });
            DropIndex("dbo.Products", new[] { "Discount_IdDiscount" });
            DropIndex("dbo.Products", new[] { "IdPack" });
            DropIndex("dbo.Products", new[] { "IdAd" });
            DropIndex("dbo.Products", new[] { "IdStock" });
            DropIndex("dbo.Products", new[] { "IdDiscount" });
            DropIndex("dbo.Products", new[] { "IdCategory" });
            DropIndex("dbo.Packs", new[] { "Ads_IdAds" });
            DropIndex("dbo.Packs", new[] { "IdAd" });
            DropIndex("dbo.Packs", new[] { "IdProduct" });
            DropIndex("dbo.Carts", new[] { "IdPack" });
            DropIndex("dbo.Carts", new[] { "IdProduct" });
            DropIndex("dbo.Carts", new[] { "IdClient" });
            DropIndex("dbo.Bills", new[] { "IdCart" });
            DropIndex("dbo.Bills", new[] { "IdClient" });
            DropIndex("dbo.Ads", new[] { "IdClient" });
            DropIndex("dbo.Ads", new[] { "IdProduct" });
            DropIndex("dbo.Ads", new[] { "IdPack" });
            DropTable("dbo.Postes");
            DropTable("dbo.Comments");
            DropTable("dbo.Resources");
            DropTable("dbo.Prospections");
            DropTable("dbo.Agents");
            DropTable("dbo.Claims");
            DropTable("dbo.Stores");
            DropTable("dbo.Stocks");
            DropTable("dbo.Discounts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Packs");
            DropTable("dbo.Carts");
            DropTable("dbo.Bills");
            DropTable("dbo.Clients");
            DropTable("dbo.Ads");
            DropTable("dbo.Admins");
        }
    }
}
