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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Gender>> Get(int id)
        {
           var gender = await context.Genders.FirstOrDefaultAsync(gender => gender.Id == id);
            if (gender is null)
            {
                return NotFound();
            }
            return gender;
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

        [HttpPut]
        public async Task<ActionResult> Put(Gender gender)
        {
            context.Update(gender);
            await context.SaveChangesAsync();
            return NoContent();//Exitoso pero sin nada de retorno
        }
    }
}
