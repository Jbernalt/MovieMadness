namespace CovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        UserRating = c.Int(nullable: false),
                        UserName = c.String(),
                        post_PostID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Post", t => t.post_PostID)
                .Index(t => t.post_PostID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        PostContent = c.String(),
                        Movie_MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieID)
                .Index(t => t.Movie_MovieID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                        Name = c.String(maxLength: 50),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Movie_MovieID", "dbo.Movie");
            DropForeignKey("dbo.Comment", "post_PostID", "dbo.Post");
            DropIndex("dbo.Post", new[] { "Movie_MovieID" });
            DropIndex("dbo.Comment", new[] { "post_PostID" });
            DropTable("dbo.Movie");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
