using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidMovieMadness.ViewModels
{
    public class MovieDetailsVM
    {
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        public int UserRating { get; set; }
        public string UserName { get; set; }


        public int PostID { get; set; }
        public int Rating { get; set; }
        public string PostContent { get; set; }

        public int MovieID { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public double AvgRating { get; set; }
    }
}