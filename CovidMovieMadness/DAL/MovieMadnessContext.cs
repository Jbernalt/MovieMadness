using CovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CovidMovieMadness.DAL
{
    public class MovieMadnessContext : DbContext
    {
        public MovieMadnessContext() : base("MovieMadnessContext")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}