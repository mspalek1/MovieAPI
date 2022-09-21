using MediatR;

namespace Services.Function.Movie.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest<BaseResponse>
    {
        public int MovieId { get; set; }
    }
}
