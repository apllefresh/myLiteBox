namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sgoodIdtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GoodInfs", "CreatorId", c => c.String());
            AlterColumn("dbo.GoodInfs", "EditorId", c => c.String());
            AlterColumn("dbo.RPrices", "CreatorId", c => c.String());
            AlterColumn("dbo.SGoods", "CreatorId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SGoods", "CreatorId", c => c.Int(nullable: false));
            AlterColumn("dbo.RPrices", "CreatorId", c => c.Int(nullable: false));
            AlterColumn("dbo.GoodInfs", "EditorId", c => c.Int(nullable: false));
            AlterColumn("dbo.GoodInfs", "CreatorId", c => c.Int(nullable: false));
        }
    }
}
