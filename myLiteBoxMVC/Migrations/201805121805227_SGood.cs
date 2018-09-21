namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SGood : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoodInfs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoodId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        fat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mult = c.Decimal(nullable: false, precision: 18, scale: 2),
                        brutto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        energy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        proteins = c.Decimal(nullable: false, precision: 18, scale: 2),
                        fats = c.Decimal(nullable: false, precision: 18, scale: 2),
                        carbohydrates = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vitamins = c.Decimal(nullable: false, precision: 18, scale: 2),
                        staff = c.String(),
                        recomendations = c.String(),
                        storage = c.String(),
                        CreatorId = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        EditorId = c.Int(nullable: false),
                        DateEdit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GoodId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SGoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GoodId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SGoods");
            DropTable("dbo.RPrices");
            DropTable("dbo.GoodInfs");
        }
    }
}
