using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Models;

namespace Services.Function.Movie.Queries
{
    public class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, MovieDto>
    {
        private readonly IMovieAsyncRepository _movieRepository;
        private readonly IMapper _mapper;
        public GetMovieDetailQueryHandler(IMovieAsyncRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle
            (GetMovieDetailQuery request, 
            CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            var movieDto = _mapper.Map<MovieDto>(movie);

            return movieDto;
        }
    }
}
