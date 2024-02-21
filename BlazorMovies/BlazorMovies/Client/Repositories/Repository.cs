using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public class Repository : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
            new Movie() { Title = "Black, Amor y Compasión", 
                DateLaunch = new DateTime(2023, 11, 11), 
                Poster = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3c/Black_Film.jpg/220px-Black_Film.jpg" },
            new Movie() { Title = "Terminator", 
                DateLaunch = new DateTime(2024, 05, 19),
                Poster = "https://upload.wikimedia.org/wikipedia/en/thumb/7/70/Terminator1984movieposter.jpg/220px-Terminator1984movieposter.jpg" },
            new Movie() { Title = "Dune", 
                DateLaunch = new DateTime(2024, 1, 21),
                Poster = "https://upload.wikimedia.org/wikipedia/en/thumb/8/8e/Dune_%282021_film%29.jpg/220px-Dune_%282021_film%29.jpg" }
            };
        }
    }
}
