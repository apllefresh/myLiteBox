namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sertifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        dateStart = c.DateTime(nullable: false),
                        dateEnd = c.DateTime(nullable: false),
                        dateReg = c.DateTime(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sertifications");
        }
    }
}
