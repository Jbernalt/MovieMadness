using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CovidMovieMadness.Models;

namespace CovidMovieMadness.DAL
{
    public class MovieMadnessInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MovieMadnessContext>
    {
        protected override void Seed(MovieMadnessContext context)
        {
            //var movies = new List<Movie>
            //{
            //    new Movie{ Name="Robotron", Genre="Action", Year=2005},
            //    new Movie{ Name="Vikingtron", Genre="Action", Year=2007}
            //};
            //movies.ForEach(s => context.Movies.Add(s));
            //context.SaveChanges();

            //var posts = new List<Post>
            //{
            //    new Post{ Rating = 5, PostContent ="This Is a Movie About a Robot"},
            //    new Post{ Rating = 7, PostContent ="This Is a Movie About a Viking"}
            //};
            //posts.ForEach(s => context.Posts.Add(s));
            //context.SaveChanges();

            //var comments = new List<Comment>
            //{
            //    new Comment{ UserName="XxLeetMasterxX", CommentContent="It was nice! I love Robots", UserRating = 10},
            //    new Comment{ UserName="VikingMaster", CommentContent="Vikings FTW", UserRating = 9}
            //};
            //comments.ForEach(s => context.Comments.Add(s));
            //context.SaveChanges();
        }
    }
}