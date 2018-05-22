namespace Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Users", "EmployeeId");
            AddForeignKey("dbo.Users", "EmployeeId", "dbo.Employees", "Id");
            DropColumn("dbo.Users", "IsEmailVerified");
            DropColumn("dbo.Users", "ActivationCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ActivationCode", c => c.Guid());
            AddColumn("dbo.Users", "IsEmailVerified", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Users", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "EmployeeId" });
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
    }
}
