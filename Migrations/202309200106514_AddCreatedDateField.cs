namespace Vivid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Movies", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreatedDate");
            DropColumn("dbo.Movies", "CreatedDate");
            DropColumn("dbo.Actors", "CreatedDate");
        }
    }
}
