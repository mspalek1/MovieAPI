using MediatR;
using Models;

namespace Services.Function.Movie.Queries
{
    public class GetMovieDetailQuery : IRequest<MovieDto>
    {
        public int Id { get; set; }
    }
}
