namespace BlazorMovies.Shared.Entities
{
    public class VoteMovie
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public DateTime DateVote { get; set; }
        public int MovieId { get; set; }

        public Movie? Movie { get; set; }
    }
}
