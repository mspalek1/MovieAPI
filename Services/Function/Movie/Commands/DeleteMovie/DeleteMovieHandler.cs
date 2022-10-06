using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Data;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Services.Authorization;
using Services.Interfaces;

namespace Services.Function.Movie.Commands.DeleteMovie
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, BaseResponse>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public DeleteMovieHandler(
            IMovieAsyncRepository movieAsyncRepository, 
            IAuthorizationService authorizationService,
            IUserContextService userContextService
            )
        {
            _movieAsyncRepository = movieAsyncRepository;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public async Task<BaseResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToDelete = await _movieAsyncRepository.GetByIdAsync(request.MovieId);

            if (movieToDelete is null)
            {
                var response = new BaseResponse($"Movie with id {request.MovieId} not found", false)
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
                return response;
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User,
                movieToDelete, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                var response = new BaseResponse($"Can not delete the movie", false)
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
                return response;
            }

            await _movieAsyncRepository.DeleteAsync(movieToDelete);

            return new BaseResponse();
        }

    }
}
