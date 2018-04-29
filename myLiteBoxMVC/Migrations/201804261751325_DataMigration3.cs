namespace myLiteBoxMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Departments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Departments", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "DepartmentId");
        }
    }
}
