namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagesToUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileExtension = c.String(),
                        Content = c.Binary(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.AspNetUsers", "ImageId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.AspNetUsers", "ImageId");
            AddForeignKey("dbo.AspNetUsers", "ImageId", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ImageId", "dbo.Images");
            DropIndex("dbo.Images", new[] { "IsDeleted" });
            DropIndex("dbo.AspNetUsers", new[] { "ImageId" });
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            DropColumn("dbo.AspNetUsers", "ImageId");
            DropTable("dbo.Images");
        }
    }
}
