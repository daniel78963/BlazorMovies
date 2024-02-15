using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public interface IRepository
    {
        List<Movie> GetMovies();
    }
}
