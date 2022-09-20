using Domain.Repositories;
using FluentValidation;

namespace Services.Function.Movie.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        private readonly IMovieAsyncRepository _movieAsyncRepository;

        public UpdateMovieCommandValidator(IMovieAsyncRepository movieAsyncRepository)
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
