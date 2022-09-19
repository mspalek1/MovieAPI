using Domain.Pages;
using Domain.Queries;
using MediatR;
using Models;

namespace Services.Function.Movie.Queries
{
    public class GetMovieListSearchQuery : IRequest<PageResult<MovieDto>>, IRequest
    {
        public MovieQuery MovieQuery { get; set; }
    }
}
