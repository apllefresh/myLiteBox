namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class depIdtoint : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Departments");
            AddColumn("dbo.Departments", "isActive", c => c.Boolean(nullable: true));
            AlterColumn("dbo.Departments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Departments", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Departments", "isActive");
            AddPrimaryKey("dbo.Departments", "Id");
        }
    }
}
