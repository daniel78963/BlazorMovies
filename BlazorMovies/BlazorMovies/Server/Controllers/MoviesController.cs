using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<HomePageDTO>> Get()
        {
            int top = 6;
            var moviesInPremier = await context.Movies
                .Where(movie => movie.InPremier)
                .Take(top)
                .OrderByDescending(movie => movie.DateLaunch)
                .ToListAsync();
            var actualDate = DateTime.Now;
            var nextPremieres = await context.Movies
                   .Where(movie => movie.DateLaunch > actualDate)
                   .Take(top)
                   .OrderByDescending(movie => movie.DateLaunch)
                   .ToListAsync();

            var result = new HomePageDTO
            {
                MoviesInPremier = moviesInPremier,
                NextPremieres = nextPremieres
            };
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieVisualizerDTO>> Get(int id)
        {
            var movie = await context.Movies.Where(movie => movie.Id == id)
                .Include(movie => movie.GendersMovie)
                    .ThenInclude(gp => gp.Gender)
                .Include(movie => movie.MoviesActor.OrderBy(pa => pa.Order))
                    .ThenInclude(movie => movie.Actor)
                .FirstOrDefaultAsync();

            if (movie is null)
            {
                return NotFound();
            }

            //TODO: sistema de votación
            var AVGVote = 4;
            var userVote = 5;

            var model = new MovieVisualizerDTO();
            model.Movie = movie;
            model.Genders = movie.GendersMovie.Select(gp => gp.Gender!).ToList();
            model.Actors = movie.MoviesActor.Select(pa => new Actor
            {
                Name = pa.Actor!.Name,
                Photo = pa.Actor.Photo,
                Character = pa.Actor.Character,
                Id = pa.ActorId
            }).ToList();
            model.AVGVote = AVGVote;
            model.UserVote = userVote;
            return model;
        }

        [HttpGet("update/{id}")]

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync(Movie movie)
        {
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                //pasar de base64 a arreglo de bytes
                var photoActor = Convert.FromBase64String(movie.Poster);
                movie.Poster = await storageFiles.SaveFile(photoActor, ".jpg", conteiner);
            }

            if (movie.MoviesActor is not null)
            {
                for (int i = 0; i < movie.MoviesActor.Count; i++)
                {
                    movie.MoviesActor[i].Order = i++;
                }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return movie.Id;
        }
    }
}
