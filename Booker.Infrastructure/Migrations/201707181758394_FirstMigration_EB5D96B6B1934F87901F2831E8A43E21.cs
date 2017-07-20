namespace Booker.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration_EB5D96B6B1934F87901F2831E8A43E21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DateOfTheVisit = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Client_UserId = c.Guid(nullable: false),
                        Employee_UserId = c.Guid(nullable: false),
                        Service_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .Index(t => t.Client_UserId)
                .Index(t => t.Employee_UserId)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        Username = c.String(),
                        FullName = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Bookings", "Employee_UserId", "dbo.Employees");
            DropForeignKey("dbo.Bookings", "Client_UserId", "dbo.Clients");
            DropIndex("dbo.Bookings", new[] { "Service_Id" });
            DropIndex("dbo.Bookings", new[] { "Employee_UserId" });
            DropIndex("dbo.Bookings", new[] { "Client_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.Bookings");
        }
    }
}
