using System.Collections.Generic;
using MediatR;
using Models;

namespace Services.Function.Movie.Queries
{
    public class GetMovieListQuery : IRequest<List<MovieDto>>
    {
    }
}
