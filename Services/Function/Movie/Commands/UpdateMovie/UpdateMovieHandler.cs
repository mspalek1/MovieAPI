using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Services.Function.Movie.Commands.CreateMovie;

namespace Services.Function.Movie.Commands.UpdateMovie
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, BaseResponse>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        private readonly IMapper _mapper;

        public UpdateMovieHandler(IMovieAsyncRepository movieAsyncRepository, IMapper mapper)
        {
            _movieAsyncRepository = movieAsyncRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = await _movieAsyncRepository.GetByIdAsync(request.MovieId);
            if (movieToUpdate is null)
            {
                return new BaseResponse($"Movie with id {request.MovieId} not found", false);
            }

            var validator = new UpdateMovieCommandValidator(_movieAsyncRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new BaseResponse(validatorResult);
            }

            movieToUpdate.Name = request.Name;
            movieToUpdate.Description = request.Description;

            await _movieAsyncRepository.UpdateAsync(movieToUpdate);

            return new BaseResponse();
        }
    }
}
