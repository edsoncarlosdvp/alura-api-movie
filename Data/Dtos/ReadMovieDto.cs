namespace api_movie.Data.Dtos
{
    public class ReadMovieDto
    {
        public string? Title { get; set; }
        public string? Genere { get; set; }
        public int Duration { get; set; }
        public DateTime? SearchHour { get; set; } = DateTime.Now;
    }
}
