using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public interface IRepository
    {
        List<Movie> GetMovies();
        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T send);
    }
}
