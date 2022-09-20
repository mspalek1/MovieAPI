using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Services.Function.Movie.Commands.DeleteMovie
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, BaseResponse>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        private readonly IMapper _mapper;

        public DeleteMovieHandler(IMovieAsyncRepository movieAsyncRepository, IMapper mapper)
        {
            _movieAsyncRepository = movieAsyncRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToDelete = await _movieAsyncRepository.GetByIdAsync(request.MovieId);

            if (movieToDelete is null)
            {
                return new BaseResponse($"Movie with id {request.MovieId} not found", false);
            }

            await _movieAsyncRepository.DeleteAsync(movieToDelete);

            return new BaseResponse();
        }

    }
}
