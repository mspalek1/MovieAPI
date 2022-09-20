using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Services.Function.Movie.Commands
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        private readonly IMapper _mapper;

        public DeleteMovieHandler(IMovieAsyncRepository movieAsyncRepository, IMapper mapper)
        {
            _movieAsyncRepository = movieAsyncRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToDelete = await _movieAsyncRepository.GetByIdAsync(request.MovieId);

            await _movieAsyncRepository.DeleteAsync(movieToDelete);

            return Unit.Value;
        }

    }
}
