using System.ComponentModel.DataAnnotations;

namespace BlazorMovies.Shared.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public string Name { get; set; }
    }
}
