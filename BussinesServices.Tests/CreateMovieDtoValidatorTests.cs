using Domain.Repositories;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Services;
using Services.Function.Movie.Commands.CreateMovie;

namespace Models
{
    [TestFixture]
    public class CreateMovieDtoValidatorTests
    {
        private CreatedMovieCommandValidator _createMovieDtoValidator;
        private Mock<IMovieAsyncRepository> _repositoryMovieMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMovieMock = RepositoryMock.GetMovieAsyncRepository();
            _createMovieDtoValidator = new CreatedMovieCommandValidator(_repositoryMovieMock.Object);
        }

        [Test]
        public void MovieDtoValidator_MovieDto_ShouldBeValid()
        {
            var movieDto = new CreatedMovieCommand();
            movieDto.Name = "Name";
            var result = _createMovieDtoValidator.TestValidate(movieDto);
            result.ShouldNotHaveValidationErrorFor(r => r.Name);
        }

        [Test]
        public void MovieDtoValidator_MovieDto_ShouldBeNotValid()
        {
            var movieDto = new CreatedMovieCommand();
            var result = _createMovieDtoValidator.TestValidate(movieDto);
            result.ShouldHaveValidationErrorFor(r => r.Name);
        }
    }
}
