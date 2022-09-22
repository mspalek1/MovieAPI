using FluentValidation.Results;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Function.Account.Queries
{
    public class LoginQueryResponse : BaseResponse
    {
        public string Token { get; set; }

        public LoginQueryResponse()
        {
        }

        public LoginQueryResponse(JwtSecurityToken securityToken) : base()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public LoginQueryResponse(string message = null) : base(message)
        {
        }

        public LoginQueryResponse(string message, bool success) : base(message, success)
        {
        }

        public LoginQueryResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
    }
}
