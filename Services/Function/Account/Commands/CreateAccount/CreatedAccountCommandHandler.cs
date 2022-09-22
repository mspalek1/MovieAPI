using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Services.Function.Account.Commands.CreateAccount
{
    public class CreatedAccountCommandHandler : IRequestHandler<CreatedAccountCommand, CreatedAccountCommandResponse>
    {
        private readonly IAsyncAccountRepository _asyncAccountRepository;
        private readonly IMapper _mapper;
        private readonly MovieDBContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreatedAccountCommandHandler(
            IAsyncAccountRepository asyncAccountRepository,
            IMapper mapper,
            MovieDBContext dbContext,
            IPasswordHasher<User> passwordHasher)
        {
            _asyncAccountRepository = asyncAccountRepository;
            _mapper = mapper;
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public async Task<CreatedAccountCommandResponse> Handle(CreatedAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatedAccountCommandValidator(_dbContext);
            var validatationResult = await validator.ValidateAsync(request);

            if (!validatationResult.IsValid)
            {
                return new CreatedAccountCommandResponse(validatationResult);
            }

            var user = _mapper.Map<User>(request);

            var hashPassword = _passwordHasher.HashPassword(user, request.Password);
            user.PasswordHash = hashPassword;

            var post = await _asyncAccountRepository.AddAsync(user);

            return new CreatedAccountCommandResponse(post.Id);
        }
    }
}
