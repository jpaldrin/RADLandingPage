namespace External.RadProApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rgitr2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Radius", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Radius");
        }
    }
}
