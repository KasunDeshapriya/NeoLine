namespace Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "NameDenoted", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "NameDenoted", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
