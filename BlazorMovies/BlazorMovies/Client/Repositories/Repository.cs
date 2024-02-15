using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public class Repository : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
            new Movie() { Title = "Black, Amor y Compasión", DateLaunch = new DateTime(2023, 11, 11) },
            new Movie() { Title = "Winter", DateLaunch = new DateTime(2024, 05, 19) },
            new Movie() { Title = "Panter", DateLaunch = new DateTime(2024, 1, 21) }
            };
        }
    }
}
