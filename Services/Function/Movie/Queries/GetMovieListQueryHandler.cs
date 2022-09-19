using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Models;

namespace Services.Function.Movie.Queries
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDto>>
    {
        private readonly IMovieAsyncRepository _movieRepository;
        private readonly IMapper _mapper;
        public GetMovieListQueryHandler(IMovieAsyncRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetAllAsync();

            var movieDto = _mapper.Map<List<MovieDto>>(movie);

            return movieDto;
        }
    }
}
