using Domain.Pages;
using Domain.Queries;
using MediatR;
using Models;

namespace Services.Function.Movie.Queries.GetMovieList
{
    public class GetMovieListSearchQuery : IRequest<PageResult<MovieDto>>, IRequest
    {
        public MovieQuery MovieQuery { get; set; }
    }
}
