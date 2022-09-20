using System.Collections.Generic;
using MediatR;
using Models;

namespace Services.Function.Movie.Queries.GetMovieList
{
    public class GetMovieListQuery : IRequest<List<MovieDto>>
    {
    }
}
