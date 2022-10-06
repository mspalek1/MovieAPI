using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Queries;
using Domain.Repositories;
using Models;
using Moq;
using NUnit.Framework;
using Services.Function.Movie.Commands.CreateMovie;
using Services.Function.Movie.Queries.GetMovieList;
using Services.Interfaces;
using Services.Mappers;
using Shouldly;

namespace Services
{
    [TestFixture]
    public class MovieServiceTests
    {
        private IMapper _mapperMock;
        private Mock<IMovieAsyncRepository> _repositoryMovieMock;
        private Mock<IUserContextService> _userContextService;
        
        [SetUp]
        public void Setup()
        {
            
           _repositoryMovieMock = RepositoryMock.GetMovieAsyncRepository();
           _userContextService = new Mock<IUserContextService>();
           
           var configurationProvider = new MapperConfiguration(cfg =>
           {
               cfg.AddProfile<MovieMappingProfile>();
           });
 
           _mapperMock = configurationProvider.CreateMapper();
        }

        [Test]
        public async Task GetAllMovies_InvokeMethod_CheckIfRepoIsCalled()
        {
            var handler = new GetMovieListQueryHandler(_repositoryMovieMock.Object, _mapperMock);
            var result = await handler.Handle(new GetMovieListQuery(), CancellationToken.None);

            _repositoryMovieMock.Verify(c=>c.GetAllAsync(), Times.Once);

            result.ShouldBeOfType<List<MovieDto>>();
            result.Count.ShouldBe(2);
        }

        [Test]
        public async Task Handle_ValidMovie_AddedToMovieRepo()
        {
            var handler = new CreatedMovieCommandHandler(_repositoryMovieMock.Object, _mapperMock, _userContextService.Object);

            var allMovieBeforeCount = (await _repositoryMovieMock.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreatedMovieCommand()
                {
                    Name = "Test",
                    Description = "Description test"
                }
                , CancellationToken.None);

            var allMovies = await _repositoryMovieMock.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allMovies.Count.ShouldBe(++allMovieBeforeCount);
        }

        [Test]
        public async Task GetMovies_InvokeMethodQueries_ValidateMovie()
        {
            var handler = new GetMovieListSearchQueryHandler(_repositoryMovieMock.Object, _mapperMock);
            var movieQuery = new MovieQuery()
            {
                SearchPhrase = "Movie1",
                PageNumber = 1,
                PageSize = 5
            };
            var request = new GetMovieListSearchQuery()
            {
                MovieQuery = movieQuery
            };

            var result = await handler.Handle(request, CancellationToken.None);

            result.Items.Count.ShouldBe(1);
            result.Items[0].Name = movieQuery.SearchPhrase;
            result.TotalPage.ShouldBe(1);
            result.TotalItemsCount.ShouldBe(1);
        }
    }
}
