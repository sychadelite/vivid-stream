namespace Vivid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        Url = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Name = c.String(),
                        Bio = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Watchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalView = c.Int(nullable: false),
                        TotalDuration = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Watchers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Watchers", "MovieId", "dbo.Movies");
            DropIndex("dbo.Watchers", new[] { "MovieId" });
            DropIndex("dbo.Watchers", new[] { "UserId" });
            DropTable("dbo.Watchers");
            DropTable("dbo.Users");
            DropTable("dbo.Movies");
        }
    }
}
