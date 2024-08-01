using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovies.Server.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IStorageFiles storageFiles;
        private readonly string conteiner = "persons";

        public ActorsController(ApplicationDbContext context, IStorageFiles storageFiles)
        {
            this.context = context;
            this.storageFiles = storageFiles;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actors.ToListAsync();
        }

        [HttpGet("search/{searchText}")]
        public async Task <ActionResult<List<Actor>>> Get(string searchText)
        {

        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync(Actor actor)
        {
            if (!string.IsNullOrWhiteSpace(actor.Photo))
            {
                //pasar de base64 a arreglo de bytes
                var photoActor = Convert.FromBase64String(actor.Photo);
                actor.Photo = await storageFiles.SaveFile(photoActor, ".jpg", conteiner);
            }

            context.Add(actor);
            await context.SaveChangesAsync();
            return actor.Id;
        }
    }
}
