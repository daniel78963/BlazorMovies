using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMovies.Server.Controllers
{
    [Route("api/genders")]
    public class GendersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GendersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //[HttpPost]
        //public async Task<ActionResult> PostAsync(Gender gender)
        //{
        //    context.Add(gender);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}
        [HttpPost]
        public async Task<ActionResult<int>> PostAsync(Gender gender)
        {
            context.Add(gender);
            await context.SaveChangesAsync();
            return gender.Id;
        }
    }
}
