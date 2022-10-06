using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Models;
using Services.Interfaces;

namespace Services.Function.Movie.Commands.CreateMovie
{
    public class CreatedMovieCommandHandler : IRequestHandler<CreatedMovieCommand, CreatedMovieCommandResponse>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public CreatedMovieCommandHandler(
            IMovieAsyncRepository movieAsyncRepository,
            IMapper mapper,
            IUserContextService userContextService)        
        {
            _movieAsyncRepository = movieAsyncRepository;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<CreatedMovieCommandResponse> Handle(CreatedMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatedMovieCommandValidator(_movieAsyncRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new CreatedMovieCommandResponse(validatorResult);
            }

            var post = _mapper.Map<Domain.Entities.Movie>(request);
            post.CreatedById = _userContextService.GetUserId;

            post = await _movieAsyncRepository.AddAsync(post);

            return new CreatedMovieCommandResponse(post.Id);
        }

    }
}
