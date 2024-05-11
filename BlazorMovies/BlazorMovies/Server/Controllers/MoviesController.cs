using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IStorageFiles storageFiles;
        private readonly string conteiner = "movies";

        public MoviesController(ApplicationDbContext context, IStorageFiles storageFiles)
        {
            this.context = context;
            this.storageFiles = storageFiles;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                //pasar de base64 a arreglo de bytes
                var photoActor = Convert.FromBase64String(movie.Poster);
                movie.Poster = await storageFiles.SaveFile(photoActor, ".jpg", conteiner);
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return movie.Id;
        }
    }
}
