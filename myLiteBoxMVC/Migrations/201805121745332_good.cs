namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class good : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ean = c.String(),
                        GroupId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                        NDSId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Goods");
        }
    }
}
