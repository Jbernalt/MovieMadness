using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CovidMovieMadness.Models
{
    public class Post
    {
        public int PostID { get; set; }
        [Range(0, 10)]
        public int Rating { get; set; }
        [Display(Name = "Post Content")]
        public string PostContent { get; set; }

        public Movie Movie { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}