using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private Movie movie1;
        private Movie movie2;
        private DbContextOptions<MovieDBContext> options;

        public MovieRepositoryTests()
        {
            movie1 = new Movie()
            {
                AgeCategory = AgeCategory.ParentalGuidance,
                Description = "Descritpion1",
                ImageURL = "http://Movie1",
                MovieCategory = MovieCategory.Action,
                MovieLength = 124,
                Name = "Movie1"
            };

            movie2 = new Movie()
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
            options = new DbContextOptionsBuilder<MovieDBContext>()
                .UseInMemoryDatabase(databaseName: "tempMovie").Options;
            
        }

        [Test]
        public void SaveMovie_MovieOne_CheckTheValueFromDB()
        {
            using (var context = new MovieDBContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new MovieRepository(context);
                repository.Create(movie1);
            }

            using (var context = new MovieDBContext(options))
            {
                var movieFromDb = context.Movie.First();
                Assert.AreEqual(movie1.MovieCategory, movieFromDb.MovieCategory);
                Assert.AreEqual(movie1.Description, movieFromDb.Description);
                Assert.AreEqual(movie1.ImageURL, movieFromDb.ImageURL);
                Assert.AreEqual(movie1.MovieLength, movieFromDb.MovieLength);
            }


        }

        [Test]
        public void GetAllMovies_MoviesOneAndTwo_CheckBothMovieFromDB()
        {
            var expectedResult = new List<Movie>
            {
                movie1,
                movie2
            };

            using (var context = new MovieDBContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new MovieRepository(context);
                repository.Create(movie1);
                repository.Create(movie2);
            }

            List<Movie> actualList;
            using (var context = new MovieDBContext(options))
            {
                var repository = new MovieRepository(context);
                actualList = repository.GetAll().ToList();
            }

            CollectionAssert.AreEqual(expectedResult, actualList, new MovieComparer());
        }

        [Test]
        public void MovieException_BadRequest_ThrowsException()
        {
            using (var context = new MovieDBContext(options))
            {
                int id = 0;
                var repository = new MovieRepository(context);
                var exception = Assert.Throws<NotFoundException>(() => repository.GetById(id));
                Assert.That(exception.Message, Is.EqualTo($"The movie with the identifier {id} was not found"));
            }
        }

        [Test]
        public void GetOneMovie_IdMovie_CheckMovieFromDB()
        {

            var expectedResult = movie1;
            using (var context = new MovieDBContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new MovieRepository(context);
                repository.Create(movie1);
            }


            Movie actual;
            using (var context = new MovieDBContext(options))
            {
                var repository = new MovieRepository(context);
                actual = repository.GetById(1);
            }

            Assert.AreEqual(movie1.Id, actual.Id);
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
