﻿using BlazorMovies.Shared.Entities;
using System.Text;
using System.Text.Json;

namespace BlazorMovies.Client.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient httpClient;
        private JsonSerializerOptions OptionsDefaultJSON => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public Repository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHttp = await httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializeAnswer<T>(responseHttp, OptionsDefaultJSON);
                return new HttpResponseWrapper<T>(response, error: false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, error: false, responseHttp);
            }
        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T send)
        {
            var sendJSON = JsonSerializer.Serialize(send);
            var sendContent = new StringContent(sendJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, sendContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T send)
        {
            var sendJSON = JsonSerializer.Serialize(send);
            var sendContent = new StringContent(sendJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, sendContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T send)
        {
            var sendJSON = JsonSerializer.Serialize(send);
            var sendContent = new StringContent(sendJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, sendContent);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializeAnswer<TResponse>(responseHttp, OptionsDefaultJSON);
                return new HttpResponseWrapper<TResponse>(response, error: false, responseHttp);
            }

            return new HttpResponseWrapper<TResponse>(default,
                !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        private async Task<T> DeserializeAnswer<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var answerString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(answerString, options);
        }

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
