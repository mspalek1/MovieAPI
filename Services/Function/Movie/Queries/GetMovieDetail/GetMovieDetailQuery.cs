using MediatR;
using Models;

namespace Services.Function.Movie.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery : IRequest<MovieDto>
    {
        public int Id { get; set; }
    }
}
