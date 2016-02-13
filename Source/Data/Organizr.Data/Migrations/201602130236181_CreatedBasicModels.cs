namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedBasicModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        OrganiserId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        LocationId = c.Int(nullable: false),
                        HasFinished = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        User_Id = c.String(maxLength: 128),
                        User_Id1 = c.String(maxLength: 128),
                        Organiser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id1)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Organiser_Id)
                .Index(t => t.LocationId)
                .Index(t => t.IsDeleted)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1)
                .Index(t => t.Organiser_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.LocationRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.LocationId)
                .Index(t => t.IsDeleted)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Event_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Location_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Event_Id1", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Event_Id");
            CreateIndex("dbo.AspNetUsers", "Location_Id");
            CreateIndex("dbo.AspNetUsers", "Event_Id1");
            AddForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.AspNetUsers", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.AspNetUsers", "Event_Id1", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Event_Id1", "dbo.Events");
            DropForeignKey("dbo.Events", "Organiser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.LocationRates", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LocationRates", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.AspNetUsers", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "User_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LocationRates", new[] { "User_Id" });
            DropIndex("dbo.LocationRates", new[] { "IsDeleted" });
            DropIndex("dbo.LocationRates", new[] { "LocationId" });
            DropIndex("dbo.Locations", new[] { "IsDeleted" });
            DropIndex("dbo.AspNetUsers", new[] { "Event_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "Location_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "Organiser_Id" });
            DropIndex("dbo.Events", new[] { "User_Id1" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropIndex("dbo.Events", new[] { "IsDeleted" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropColumn("dbo.AspNetUsers", "Event_Id1");
            DropColumn("dbo.AspNetUsers", "Location_Id");
            DropColumn("dbo.AspNetUsers", "Event_Id");
            DropColumn("dbo.AspNetUsers", "BirthDay");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.LocationRates");
            DropTable("dbo.Locations");
            DropTable("dbo.Events");
        }
    }
}
