using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Pages;
using Domain.Repositories;
using MediatR;
using Models;

namespace Services.Function.Movie.Queries
{
    public class GetMovieListSearchQueryHandler : IRequestHandler<GetMovieListSearchQuery, PageResult<MovieDto>>
    {
        private readonly IMovieAsyncRepository _movieRepository;
        private readonly IMapper _mapper;
        public GetMovieListSearchQueryHandler(IMovieAsyncRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<PageResult<MovieDto>> Handle(GetMovieListSearchQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetPagedAsyncWithQuery(request.MovieQuery);

            var movieDto = _mapper.Map<List<MovieDto>>(movie.Items);

            var result = new PageResult<MovieDto>(movieDto, movie.TotalItemsCount, movie.ItemsFrom, movie.ItemsTo,
                movie.TotalPage);

            return result;
        }
    }
}
