using MediatR;

namespace Services.Function.Account.Queries
{
    public class LoginQuery : IRequest<LoginQueryResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
