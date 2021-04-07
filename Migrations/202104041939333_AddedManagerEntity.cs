namespace UberDriver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManagerEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supervisors", "UserId", "dbo.Users");
            DropIndex("dbo.Supervisors", new[] { "UserId" });
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Supervisors", "ManagerId", c => c.Int());
            AlterColumn("dbo.Supervisors", "UserId", c => c.Int());
            CreateIndex("dbo.Supervisors", "UserId");
            CreateIndex("dbo.Supervisors", "ManagerId");
            AddForeignKey("dbo.Supervisors", "ManagerId", "dbo.Managers", "Id");
            AddForeignKey("dbo.Supervisors", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supervisors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Managers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Supervisors", "ManagerId", "dbo.Managers");
            DropIndex("dbo.Managers", new[] { "UserId" });
            DropIndex("dbo.Supervisors", new[] { "ManagerId" });
            DropIndex("dbo.Supervisors", new[] { "UserId" });
            AlterColumn("dbo.Supervisors", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Supervisors", "ManagerId");
            DropTable("dbo.Managers");
            CreateIndex("dbo.Supervisors", "UserId");
            AddForeignKey("dbo.Supervisors", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
