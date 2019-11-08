namespace External.RadProApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rgitr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Telephone", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageData", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "AcceptTerms", c => c.String());
            AddColumn("dbo.AspNetUsers", "IpAddress", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageMimeType");
            DropColumn("dbo.AspNetUsers", "IpAddress");
            DropColumn("dbo.AspNetUsers", "AcceptTerms");
            DropColumn("dbo.AspNetUsers", "ImageData");
            DropColumn("dbo.AspNetUsers", "Telephone");
            DropColumn("dbo.AspNetUsers", "LName");
            DropColumn("dbo.AspNetUsers", "FName");
        }
    }
}
