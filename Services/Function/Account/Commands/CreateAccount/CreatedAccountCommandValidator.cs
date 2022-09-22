using System.Linq;
using System.Xml.Xsl;
using Domain.Repositories;
using FluentValidation;
using Persistence;

namespace Services.Function.Account.Commands.CreateAccount
{
    public class CreatedAccountCommandValidator : AbstractValidator<CreatedAccountCommand>
    {

        public CreatedAccountCommandValidator(MovieDBContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MinimumLength(8)
                .WithMessage("{PropertyName} must not exceed 8 characters");
            RuleFor(x=> x.ConfirmPassword)
                .Equal(e => e.Password)
                .WithMessage("{PropertyName} must be the same like Password");
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(user => user.Email.Equals(value));
                    if (emailInUse)
                    {
                        context.AddFailure("{PropertyName}", $"That email: {value} is taken");
                    }
                });
        }
    }
}
