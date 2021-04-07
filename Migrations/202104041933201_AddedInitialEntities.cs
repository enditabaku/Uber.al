namespace UberDriver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInitialEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LicenseId = c.String(nullable: false),
                        LicenseDate = c.DateTime(nullable: false),
                        LicenseExpireDate = c.DateTime(nullable: false),
                        OperatingArea = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        CarInfo = c.String(),
                        Plate = c.String(nullable: false),
                        SupervisorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supervisors", t => t.SupervisorId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SupervisorId);

            CreateTable(
                "dbo.Supervisors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: true),
                    StartDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        RoleId = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                        IsDriver = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Supervisors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Drivers", "SupervisorId", "dbo.Supervisors");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Supervisors", new[] { "UserId" });
            DropIndex("dbo.Drivers", new[] { "SupervisorId" });
            DropIndex("dbo.Drivers", new[] { "UserId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Supervisors");
            DropTable("dbo.Drivers");
        }
    }
}
