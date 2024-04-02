using System.ComponentModel.DataAnnotations;

namespace BlazorMovies.Shared.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public bool InPremier { get; set; }
        public string? Trailer { get; set; }  
        public DateTime? DateLaunch { get; set; }
        public string? Poster { get; set; } 
        public string? TitleShort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    return null;
                }
                if (Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }
                else
                {
                    return Title;
                }
            }
        }
        public List<GenderMovie> GendersMovie { get; set; } = new List<GenderMovie>();
        public List<MovieActor> MoviesActor { get; set; } = new List<MovieActor>();
    }
}
