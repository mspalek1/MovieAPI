using Domain.Repositories;
using FluentValidation;

namespace Services.Function.Movie.Commands.CreateMovie
{
    public class CreatedMovieCommandValidator : AbstractValidator<CreatedMovieCommand>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;
        public CreatedMovieCommandValidator(IMovieAsyncRepository movieAsyncRepository)
        {
            _movieAsyncRepository = movieAsyncRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(80)
                .WithMessage("{PropertyName} must not exceed 80 characters");
        }
    }
}
