using System.ComponentModel.DataAnnotations;

namespace CovidMovieMadness.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        [Range(0, 10)]
        public int UserRating { get; set; }
        public string UserName { get; set; }

        public Post post { get; set; }
    }
}