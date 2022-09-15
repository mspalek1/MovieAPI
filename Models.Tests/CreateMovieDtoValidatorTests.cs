using Domain.Queries;
using FluentValidation.TestHelper;
using Models.Validators;
using NUnit.Framework;

namespace Models
{
    [TestFixture]
    public class CreateMovieDtoValidatorTests
    {
        private CreateMovieDtoValidator _createMovieDtoValidator;

        [SetUp]
        public void Setup()
        {
            _createMovieDtoValidator = new CreateMovieDtoValidator();
        }

        [Test]
        public void MovieDtoValidator_MovieDto_ShouldBeValid()
        {
            var movieDto = new CreateMovieDto();
            movieDto.Name = "Name";
            var result = _createMovieDtoValidator.TestValidate(movieDto);
            result.ShouldNotHaveValidationErrorFor(r => r.Name);
        }

        [Test]
        public void MovieDtoValidator_MovieDto_ShouldBeNotValid()
        {
            var movieDto = new CreateMovieDto();
            var result = _createMovieDtoValidator.TestValidate(movieDto);
            result.ShouldHaveValidationErrorFor(r => r.Name);
        }
    }
}
