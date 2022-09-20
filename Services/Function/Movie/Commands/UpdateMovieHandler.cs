using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Services.Function.Movie.Commands
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        private readonly IMapper _mapper;

        public UpdateMovieHandler(IMovieAsyncRepository movieAsyncRepository, IMapper mapper)
        {
            _movieAsyncRepository = movieAsyncRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Domain.Entities.Movie>(request);

            await _movieAsyncRepository.UpdateAsync(movie);

           return Unit.Value;
        }
    }
}
