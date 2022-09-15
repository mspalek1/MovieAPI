using System.Linq;
using Domain.Entities;
using Domain.Queries;
using FluentValidation;

namespace Models.Validators
{
    public class MovieQueryValidator : AbstractValidator<MovieQuery>
    {
        private readonly int[] _allowedPageSize = new[] { 1, 5, 10, 15 };

        private readonly string[] _allowedSortByColumnNames =
        {
            nameof(Movie.Name),
            nameof(Movie.Description),
            nameof(Movie.MovieLength),
        };

        public MovieQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThan(0);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!_allowedPageSize.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", _allowedPageSize)}]");
                }
            });

            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || _allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional or must be int [{string.Join(",", _allowedSortByColumnNames)}]");
        }
    }
}
