namespace BlazorMovies.Shared.Entities
{
    public class GenderMovie
    {
        public int MovieId { get; set; }
        public int GenderId { get; set; }

        //Por convensión debe ir MovieId igual que Movie, así EntityFramework entiende que es la llave foranea 
        public Movie Movie { get; set; }
        public Gender Gender { get; set; }
    }
}
