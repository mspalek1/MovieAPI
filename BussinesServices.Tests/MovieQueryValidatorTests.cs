using Domain.Entities;
using Domain.Queries;
using FluentValidation.TestHelper;
using Models.Validators;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Models
{
    [TestFixture]
    public class MovieQueryValidatorTests
    {
        private MovieQueryValidator _movieQueryValidator;

        [SetUp]
        public void Setup()
        {
            _movieQueryValidator = new MovieQueryValidator();
        }


        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        public void MovieQueriesValidator_PageSize_ShouldBeValid(int pageSize)
        {
            var movieQuery = new MovieQuery();
            movieQuery.PageSize = pageSize;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            result.ShouldNotHaveValidationErrorFor(r => r.PageSize);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(25)]
        [TestCase(-15)]
        public void MovieQueriesValidator_PageSize_ShouldBeNotValid(int pageSize)
        {
            var movieQuery = new MovieQuery();
            movieQuery.PageSize = pageSize;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            result.ShouldHaveValidationErrorFor(r => r.PageSize);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        public void MovieQueriesValidator_PageNumber_ShouldBeValid(int pageNumber)
        {
            var movieQuery = new MovieQuery();
            movieQuery.PageNumber = pageNumber;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            result.ShouldNotHaveValidationErrorFor(r => r.PageNumber);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-25)]
        [TestCase(-15)]
        public void MovieQueriesValidator_PageNumber_ShouldBeNotValid(int pageNumber)
        {
            var movieQuery = new MovieQuery();
            movieQuery.PageNumber = pageNumber;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            result.ShouldHaveValidationErrorFor(r => r.PageNumber);
        }


        private readonly string[] _allowedSortByColumnNames =
        {
            nameof(Movie.Name),
            nameof(Movie.Description),
            nameof(Movie.MovieLength),
        };

        [TestCase(nameof(Movie.Name))]
        [TestCase(nameof(Movie.Description))]
        [TestCase(nameof(Movie.MovieLength))]

        public void MovieQueriesValidator_SortByColumn_ShouldBeValid(string columnName)
        {
            var movieQuery = new MovieQuery();
            movieQuery.SortBy = columnName;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            result.ShouldNotHaveValidationErrorFor(r => r.SortBy);
        }

        [TestCase(nameof(Movie.AgeCategory))]
        [TestCase(nameof(Movie.Price))]
        public void MovieQueriesValidator_SortByColumn_ShouldBeNotValid(string columnName)
        {
            var movieQuery = new MovieQuery();
            movieQuery.SortBy = columnName;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            result.ShouldHaveValidationErrorFor(r => r.SortBy);
        }

        [Test]
        public void MovieQueriesValidator_AllQuery_ShouldBeValid()
        {
            var movieQuery = new MovieQuery();
            movieQuery.SortBy = nameof(Movie.Name);
            movieQuery.PageNumber = 1;
            movieQuery.PageSize = 5;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            Assert.That(result.IsValid, Is.True);
        }

        [Test]
        public void MovieQueriesValidator_AllQuery_ShouldBeNotValid()
        {
            var movieQuery = new MovieQuery();
            movieQuery.SortBy = nameof(Movie.Name);
            movieQuery.PageNumber = -1;
            movieQuery.PageSize = 5;
            var result = _movieQueryValidator.TestValidate(movieQuery);
            Assert.That(result.IsValid, Is.False);
        }

    }
}
