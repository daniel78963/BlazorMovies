using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        List<Movie> GetMovies();
        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T send);
        Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T send);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T send);
    }
}
