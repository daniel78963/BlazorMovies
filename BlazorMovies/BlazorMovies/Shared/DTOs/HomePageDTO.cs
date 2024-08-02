using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Shared.DTOs
{
    public class HomePageDTO
    {
        public List<Movie>? MoviesInPremier { get; set; }
        public List<Movie>? NextPremieres { get; set; }
    }
}
