using BlazorMovies.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovies.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            //estamos pasando que parametros o condiciones vamos a usar para nuestros repositorios, ej: db de que tipo
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GenderMovie>().HasKey(x => new { x.MovieId, x.GenderId });
            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });
        }

        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<GenderMovie> GendersMovies => Set<GenderMovie>();
        public DbSet<MovieActor> MoviesActors => Set<MovieActor>();
    }
}
