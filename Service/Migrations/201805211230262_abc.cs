namespace Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 10),
                        NameDenoted = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        sex = c.String(),
                        NICNumber = c.String(maxLength: 10),
                        Address = c.String(),
                        JoinedDate = c.DateTime(nullable: false),
                        ResignationDate = c.DateTime(nullable: false),
                        ActiveStatus = c.Int(nullable: false),
                        Mobile = c.Int(nullable: false),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        EmployeeId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ActiveStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "EmployeeId" });
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
        }
    }
}
