using FluentValidation.Results;

namespace Services.Function.Movie.Commands.CreateMovie
{
    public class CreatedMovieCommandResponse : BaseResponse
    {
        public CreatedMovieCommandResponse() : base()
        {
        }

        public CreatedMovieCommandResponse(string message = null) : base(message)
        {
        }

        public CreatedMovieCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreatedMovieCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public int MovieId { get; set; }

        public CreatedMovieCommandResponse(int movieId) : base()
        {
            MovieId = movieId;
        }
    }
}
