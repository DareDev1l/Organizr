namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationForEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationOnMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Locations", "LocationOnMapId", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "LocationOnMapId");
            AddForeignKey("dbo.Locations", "LocationOnMapId", "dbo.LocationOnMaps", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "LocationOnMapId", "dbo.LocationOnMaps");
            DropIndex("dbo.LocationOnMaps", new[] { "IsDeleted" });
            DropIndex("dbo.Locations", new[] { "LocationOnMapId" });
            DropColumn("dbo.Locations", "LocationOnMapId");
            DropTable("dbo.LocationOnMaps");
        }
    }
}
