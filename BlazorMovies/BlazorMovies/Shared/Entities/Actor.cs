using System.ComponentModel.DataAnnotations;

namespace BlazorMovies.Shared.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Biography { get; set; }
        public string? Photo { get; set; }
        public DateTime? DateBirth { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Actor actor) 
            {
                return Id == actor.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
