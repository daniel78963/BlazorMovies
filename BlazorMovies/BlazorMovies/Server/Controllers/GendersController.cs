using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovies.Server.Controllers
{
    [Route("api/genders")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GendersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> Get()
        {
            return await context.Genders.ToListAsync();
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
            //return BadRequest("Este es un mensaje de error personalizado");
            //throw new NotImplementedException();
            context.Add(gender);
            await context.SaveChangesAsync();
            return gender.Id;
        }
    }
}
