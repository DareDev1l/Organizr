namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationsOwnedtoUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Location_Id", "dbo.Locations");
            DropIndex("dbo.AspNetUsers", new[] { "Location_Id" });
            CreateTable(
                "dbo.LocationUsers",
                c => new
                    {
                        Location_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Location_Id, t.User_Id })
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Location_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.AspNetUsers", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Location_Id", c => c.Int());
            DropForeignKey("dbo.LocationUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationUsers", "Location_Id", "dbo.Locations");
            DropIndex("dbo.LocationUsers", new[] { "User_Id" });
            DropIndex("dbo.LocationUsers", new[] { "Location_Id" });
            DropTable("dbo.LocationUsers");
            CreateIndex("dbo.AspNetUsers", "Location_Id");
            AddForeignKey("dbo.AspNetUsers", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
