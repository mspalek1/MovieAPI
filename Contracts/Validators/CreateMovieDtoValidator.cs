using System.Data;
using FluentValidation;
using Persistence;

namespace Models.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        public CreateMovieDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
