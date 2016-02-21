namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReceiverInFriendRequest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FriendRequests", "SenderId", "dbo.AspNetUsers");
            AddColumn("dbo.FriendRequests", "ReceiverId", c => c.String(maxLength: 128));
            AddColumn("dbo.FriendRequests", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.FriendRequests", "ReceiverId");
            CreateIndex("dbo.FriendRequests", "User_Id");
            AddForeignKey("dbo.FriendRequests", "ReceiverId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendRequests", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequests", "ReceiverId", "dbo.AspNetUsers");
            DropIndex("dbo.FriendRequests", new[] { "User_Id" });
            DropIndex("dbo.FriendRequests", new[] { "ReceiverId" });
            DropColumn("dbo.FriendRequests", "User_Id");
            DropColumn("dbo.FriendRequests", "ReceiverId");
            AddForeignKey("dbo.FriendRequests", "SenderId", "dbo.AspNetUsers", "Id");
        }
    }
}
