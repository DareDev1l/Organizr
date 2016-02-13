namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedUserIds : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Events", new[] { "Organiser_Id" });
            DropIndex("dbo.LocationRates", new[] { "User_Id" });
            DropColumn("dbo.Events", "OrganiserId");
            DropColumn("dbo.LocationRates", "UserId");
            RenameColumn(table: "dbo.Events", name: "Organiser_Id", newName: "OrganiserId");
            RenameColumn(table: "dbo.LocationRates", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Events", "OrganiserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LocationRates", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.LocationRates", "Value", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "OrganiserId");
            CreateIndex("dbo.LocationRates", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.LocationRates", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "OrganiserId" });
            AlterColumn("dbo.LocationRates", "Value", c => c.Double(nullable: false));
            AlterColumn("dbo.LocationRates", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "OrganiserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.LocationRates", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Events", name: "OrganiserId", newName: "Organiser_Id");
            AddColumn("dbo.LocationRates", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "OrganiserId", c => c.Int(nullable: false));
            CreateIndex("dbo.LocationRates", "User_Id");
            CreateIndex("dbo.Events", "Organiser_Id");
        }
    }
}
