namespace UberDriver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsActiveFieldForMostEntites : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Drivers", "IsBusy", c => c.Boolean(nullable: false));
            AddColumn("dbo.Supervisors", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Managers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Managers", "IsActive");
            DropColumn("dbo.Supervisors", "IsActive");
            DropColumn("dbo.Drivers", "IsBusy");
            DropColumn("dbo.Drivers", "IsActive");
        }
    }
}
