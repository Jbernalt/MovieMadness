using CovidMovieMadness.Models;
using System.Collections.Generic;

namespace CovidMovieMadness.ViewModels
{
    public class MovieIndexData
    {

        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}