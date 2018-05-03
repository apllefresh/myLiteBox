namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NDS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NDS");
        }
    }
}
