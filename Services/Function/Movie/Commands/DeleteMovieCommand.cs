using MediatR;

namespace Services.Function.Movie.Commands
{
    public class DeleteMovieCommand : IRequest
    {
        public int MovieId { get; set; }
    }
}
