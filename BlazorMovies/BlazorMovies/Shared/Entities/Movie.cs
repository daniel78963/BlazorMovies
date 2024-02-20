namespace BlazorMovies.Shared.Entities
{
    public class Movie
    {
        public string? Title { get; set; }
        public DateTime DateLaunch { get; set; }
        public string Poster { get; set; } = null!;
        public string? TitleShort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    return null;
                }
                if (Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}
