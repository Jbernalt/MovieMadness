using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CovidMovieMadness.Models
{
    public class Movie
    {
        
        public int MovieID { get; set; }
        public string Genre { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters."), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s\w-]*$")]
        public string Name { get; set; }
        [Range(1800, 2100)]
        public int Year { get; set; }

        //Jag vet att det skulle vara en 1-01 relation till post men detta var det ända sättet för att få select till post att fungera :(
        //Hoppas detta är ok.
        public virtual ICollection<Post> Posts { get; set; }
    }
}
