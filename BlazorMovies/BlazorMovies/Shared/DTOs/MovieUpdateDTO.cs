using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Shared.DTOs
{
    public class MovieUpdateDTO
    {
        public Movie Movie { get; set; } = null!;
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public List<Gender> GendersSelecteds { get; set; } = new List<Gender>();
        public List<Gender> GendersNoSelecteds { get; set; } = new List<Gender>();

    }
}
