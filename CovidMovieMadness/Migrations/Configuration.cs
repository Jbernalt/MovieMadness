namespace CovidMovieMadness.Migrations
{
    using CovidMovieMadness.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CovidMovieMadness.DAL.MovieMadnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CovidMovieMadness.DAL.MovieMadnessContext context)
        {
            var movie1 = new Movie() { Name = "Terminator", Genre = "Action", Year = 2001 };
            var movie2 = new Movie() { Name = "Robotron", Genre = "Action", Year = 2002 };
            var movie3 = new Movie() { Name = "Vikingtron", Genre = "Adventure", Year = 2003 };
            var movie4 = new Movie() { Name = "Spiderman", Genre = "Action", Year = 2004 };
            var movie5 = new Movie() { Name = "Warcraft", Genre = "Action", Year = 2005 };

            var comment1 = new Comment() { UserName = "DraginSlayor", UserRating = 8, CommentContent = "Vary good!" };
            var comment2 = new Comment() { UserName = "xXLeetMasterXx", UserRating = 10, CommentContent = "Vary vary good!" };
            var comment3 = new Comment() { UserName = "DarkMaster420", UserRating = 7, CommentContent = "Good" };
            var comment4 = new Comment() { UserName = "Killerman69", UserRating = 5, CommentContent = "ok" };
            var comment5 = new Comment() { UserName = "Deathguy123", UserRating = 6, CommentContent = "Vary ok" };
            var comment6 = new Comment() { UserName = "Ponylover321", UserRating = 4, CommentContent = "Not ok" };

            var post1 = new Post() { Movie = movie1, Rating = 4, PostContent = "Movie about Robotman", Comments = new List<Comment>() { comment1, comment2 } };
            var post2 = new Post() { Movie = movie2, Rating = 2, PostContent = "Movie about robotrobot", Comments = new List<Comment>() { comment3, comment4 } };
            var post3 = new Post() { Movie = movie3, Rating = 5, PostContent = "Movie about vikingrobot", Comments = new List<Comment>() { comment5, comment6 } };
            var post4 = new Post() { Movie = movie4, Rating = 9, PostContent = "Movie about Robotman 2" };

            context.Movies.AddOrUpdate(movie1, movie2, movie3, movie4, movie5);
            context.Comments.AddOrUpdate(comment1, comment2, comment3, comment4, comment5, comment6);
            context.Posts.AddOrUpdate(post1, post2, post3, post4);
            context.SaveChanges();

        }
    }
}
