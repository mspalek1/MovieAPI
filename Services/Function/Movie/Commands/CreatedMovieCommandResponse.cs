namespace Services.Function.Movie.Commands
{
    public class CreatedMovieCommandResponse
    {
        public int MovieId { get; set; }

        public CreatedMovieCommandResponse(int movieId)
        {
            MovieId = movieId;
        }
    }
}
