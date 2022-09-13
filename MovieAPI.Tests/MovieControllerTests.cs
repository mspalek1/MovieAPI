using Moq;
using MovieAPI.Presentations.Controllers;
using NUnit.Framework;
using Services.Interfaces;
using Services.Services;

namespace MovieAPI
{
    [TestFixture]
    public class MovieControllerTests
    {
        private Mock<IServiceManager> _serviceManager;
        private Mock<IMovieService> _movieService;
        private MovieController _movieController;

        [SetUp]
        public void SetUp()
        {
            _movieService = new Mock<IMovieService>();
            _serviceManager = new Mock<IServiceManager>();
            _serviceManager.Setup(s => s.MovieService).Returns(_movieService.Object);
            
            _movieController = new MovieController(_serviceManager.Object);
        }

        [Test]
        public void GetAll_CallRequest_VerifyGetAllInvoked()
        {
            _movieController.GetAll();
            _serviceManager.Verify(x=>x.MovieService.GetAll(), Times.Once);
        }
    }
}
