//using System.Collections.Generic;
//using AutoMapper;
//using Domain.Data;
//using Domain.Entities;
//using Domain.Repositories;
//using Moq;
//using NUnit.Framework;
//using NUnit.Framework.Internal;
//using Services.Services;

//namespace Services
//{
//    [TestFixture]
//    public class MovieServiceTests
//    {
//        private MovieService _movieService;
//        private Mock<IServiceManagerRepository> _serviceManagerRepoMock;
//        private Mock<IMapper> _mapperMock;

//        private List<Movie> _availableMovie;

//        [SetUp]
//        public void Setup()
//        {
//            _availableMovie = new List<Movie>()
//            {
//                new Movie()
//                {
//                    AgeCategory = AgeCategory.ParentalGuidance,
//                    Description = "Descritpion1",
//                    ImageURL = "http://Movie1",
//                    MovieCategory = MovieCategory.Action,
//                    MovieLength = 124,
//                    Name = "Movie1"
//                }
//            };
//            _serviceManagerRepoMock = new Mock<IServiceManagerRepository>();
//            _serviceManagerRepoMock.Setup(x => x.MovieRepository.GetAll())
//                .Returns(_availableMovie);
//            _mapperMock = new Mock<IMapper>();
//            _movieService = new MovieService(_serviceManagerRepoMock.Object, _mapperMock.Object);
//        }

//        [Test]
//        public void GetAllMOvies_InvokeMethod_CheckIfRepoIsCalled()
//        {
//            _movieService.GetAll();
//            _serviceManagerRepoMock.Verify(c=>c.MovieRepository.GetAll(), Times.Once);
//        }
//    }
//}
