namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFriendshipRequets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.String(nullable: false, maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.AspNetUsers", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "User_Id");
            AddForeignKey("dbo.AspNetUsers", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.AspNetUsers");
            DropIndex("dbo.FriendRequests", new[] { "IsDeleted" });
            DropIndex("dbo.FriendRequests", new[] { "SenderId" });
            DropIndex("dbo.AspNetUsers", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "User_Id");
            DropTable("dbo.FriendRequests");
        }
    }
}
