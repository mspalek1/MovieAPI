using AutoMapper;
using Domain.Repositories;
using MediatR;
using Models;
using Moq;
using MovieAPI.Presentations.Controllers;
using NUnit.Framework;
using Services.Function.Movie.Queries.GetMovieList;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieAPI
{
    [TestFixture]
    public class MovieControllerTests
    {
        private MovieController _movieController;
        private Mock<IMediator> _mediator;
        private Mock<IMovieAsyncRepository> _movieRepository;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _mediator = new Mock<IMediator>();
            _movieRepository = new Mock<IMovieAsyncRepository>();
            _mapperMock = new Mock<IMapper>();
            _movieController = new MovieController(_mediator.Object);
        }

        [Test]
        public async Task GetAll_CallRequest_VerifyGetAllInvoked()
        {
            //Arranged
            _mediator.Setup(x => x.Send(It.IsAny<GetMovieListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<MovieDto>());

            //Act
             var result = await _movieController.GetAsyncAll();

            //Assert
            _mediator.Verify(x=>x.Send(It.IsAny<GetMovieListQuery>(), It.IsAny<CancellationToken>()),
                Times.Once);

        }
    }
}
