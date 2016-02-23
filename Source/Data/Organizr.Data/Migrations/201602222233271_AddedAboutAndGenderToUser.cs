namespace Organizr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAboutAndGenderToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "About", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "About");
        }
    }
}
