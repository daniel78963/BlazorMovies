using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Shared.DTOs
{
    public class MovieVisualizerDTO
    {
        //Perdonar el null: null!
        public Movie Movie { get; set; } = null!;
        public List<Gender> Genders { get; set; } = new List<Gender>();
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public int UserVote { get; set; }
        public double AVGVote { get; set; }
    }
}
