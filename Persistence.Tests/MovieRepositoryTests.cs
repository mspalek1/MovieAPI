using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Persistence.Repositories;

namespace Persistence
{
    [TestFixture]
    public class MovieRepositoryTests
    {
        private Movie _movie1;
        private Movie _movie2;
        private DbContextOptions<MovieDBContext> _options;

        public MovieRepositoryTests()
        {
            _movie1 = new Movie()
            {
                AgeCategory = AgeCategory.ParentalGuidance,
                Description = "Descritpion1",
                ImageURL = "http://Movie1",
                MovieCategory = MovieCategory.Action,
                MovieLength = 124,
                Name = "Movie1"
            };

            _movie2 = new Movie()
            {
                AgeCategory = AgeCategory.ParentalGuidance,
                Description = "Descritpion2",
                ImageURL = "http://Movie2",
                MovieCategory = MovieCategory.Action,
                MovieLength = 248,
                Name = "Movie2"
            };
        }

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<MovieDBContext>()
                .UseInMemoryDatabase(databaseName: "tempMovie").Options;

        }

        [Test]
        public async Task SaveMovie_MovieOne_CheckTheValueFromDB()
        {
            await using (var context = new MovieDBContext(_options))
            {
                context.Database.EnsureDeleted();
                var repository = new MovieAsyncRepository(context);
                await repository.AddAsync(_movie1);
            }

            await using(var context = new MovieDBContext(_options))
            {
                var movieFromDb = context.Movie.First();
                Assert.AreEqual(_movie1.MovieCategory, movieFromDb.MovieCategory);
                Assert.AreEqual(_movie1.Description, movieFromDb.Description);
                Assert.AreEqual(_movie1.ImageURL, movieFromDb.ImageURL);
                Assert.AreEqual(_movie1.MovieLength, movieFromDb.MovieLength);
            }


        }

        [Test]
        public async Task GetAllMovies_MoviesOneAndTwo_CheckBothMovieFromDB()
        {
            var expectedResult = new List<Movie>
            {
                _movie1,
                _movie2
            };

            await using(var context = new MovieDBContext(_options))
            {
                context.Database.EnsureDeleted();
                var repository = new MovieAsyncRepository(context);
                await repository.AddAsync(_movie1);
                await repository.AddAsync(_movie2);
            }

            List<Movie> actualList;
            await using(var context = new MovieDBContext(_options))
            {
                var repository = new MovieAsyncRepository(context);
                actualList = repository.GetAllAsync().Result.ToList();
            }
         

            CollectionAssert.AreEqual(expectedResult, actualList, new MovieComparer());
        }

        [Test]
        public async Task MovieException_BadRequest_ThrowsException()
        {
            await using(var context = new MovieDBContext(_options))
            {
                int id = 0;
                var repository = new MovieAsyncRepository(context);
                var exception = Assert.ThrowsAsync<NotFoundException>(async() => await repository.GetByIdAsync(id));
                Assert.That(exception.Message, Is.EqualTo($"The object Domain.Entities.Movie with the identifier {id} was not found"));
            }
        }

        [Test]
        public async Task GetOneMovie_IdMovie_CheckMovieFromDB()
        {

            var expectedResult = _movie1;
            await using(var context = new MovieDBContext(_options))
            {
                context.Database.EnsureDeleted();
                var repository = new MovieAsyncRepository(context);
                await repository.AddAsync(_movie1);
            }


            Movie actual;
            await using(var context = new MovieDBContext(_options))
            {
                var repository = new MovieAsyncRepository(context);
                actual = await repository.GetByIdAsync(1);
            }

            Assert.AreEqual(_movie1.Id, actual.Id);
        }

        private class MovieComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var movie1 = (Movie)x;
                var movie2 = (Movie)y;

                if (movie1.Id != movie2.Id)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }


}
