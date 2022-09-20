using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Models;

namespace Services.Function.Movie.Commands
{
    public class CreatedMovieCommandHandler : IRequestHandler<CreatedMovieCommand, CreatedMovieCommandResponse>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        private readonly IMapper _mapper;

        public CreatedMovieCommandHandler(IMovieAsyncRepository movieAsyncRepository, IMapper mapper)
        {
            _movieAsyncRepository = movieAsyncRepository;
            _mapper = mapper;

        }

        public async Task<CreatedMovieCommandResponse> Handle(CreatedMovieCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Domain.Entities.Movie>(request);

            post = await _movieAsyncRepository.AddAsync(post);

            return new CreatedMovieCommandResponse(post.Id);
        }
        
    }
}
