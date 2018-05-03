namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Manufacturer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        INN = c.String(maxLength: 12),
                        Country = c.String(),
                        Subject = c.String(),
                        Distrinct = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        ZipCode = c.String(maxLength: 6),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Manufacturers");
        }
    }
}
