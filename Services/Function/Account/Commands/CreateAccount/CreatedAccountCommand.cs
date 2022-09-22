using System;
using MediatR;

namespace Services.Function.Account.Commands.CreateAccount
{
    public class CreatedAccountCommand : IRequest<CreatedAccountCommandResponse>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
