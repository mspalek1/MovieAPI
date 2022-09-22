using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Services.Function.Account.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse>
    {
        private readonly IAsyncAccountRepository _asyncAccountRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public LoginQueryHandler
            (
                IAsyncAccountRepository asyncAccountRepository,
                IPasswordHasher<User> passwordHasher,
                AuthenticationSettings authenticationSettings)
        {
            _asyncAccountRepository = asyncAccountRepository;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public async Task<LoginQueryResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _asyncAccountRepository.GetUserByEmailWithRoleAsync(request.Email);

            if (user is null)
            {
                return new LoginQueryResponse("Invalid username or password", false);
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return new LoginQueryResponse("Invalid username or password", false);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"), 
                new Claim("DateOfBirth", $"{user.DateOfBirth.Value.ToString("yyyy-MM-dd")}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            
            return new LoginQueryResponse(token);
        }
    }
}
