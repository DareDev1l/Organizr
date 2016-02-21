namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCoordinates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordinates",
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
            
            AddColumn("dbo.Events", "CoordinatesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "CoordinatesId");
            AddForeignKey("dbo.Events", "CoordinatesId", "dbo.Coordinates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CoordinatesId", "dbo.Coordinates");
            DropIndex("dbo.Events", new[] { "CoordinatesId" });
            DropIndex("dbo.Coordinates", new[] { "IsDeleted" });
            DropColumn("dbo.Events", "CoordinatesId");
            DropTable("dbo.Coordinates");
        }
    }
}
