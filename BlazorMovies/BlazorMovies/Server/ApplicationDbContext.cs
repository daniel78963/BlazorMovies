using Microsoft.EntityFrameworkCore;

namespace BlazorMovies.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            //estamos pasando que parametros o condiciones vamos a usar para nuestros repositorios, ej: db de que tipo
        }
    }
}
