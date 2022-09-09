using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MovieSeeder
    {
        private readonly MovieDBContext _dbContext;

        public MovieSeeder(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Producers.Any())
                {
                    var producers = GetProducers();
                    _dbContext.Producers.AddRange(producers);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Movie.Any())
                {
                    var movies = GetMovies();
                    _dbContext.Movie.AddRange(movies);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Producer> GetProducers()
        {
            var producers = new List<Producer>()
            {
                new Producer()
                {
                    FullName = "Producer 1",
                    BiographyURL = "http://Producer1/bio",
                    PictureURL = "http://Producer1/photo1.jpg"
                },

                new Producer()
                {
                    FullName = "Producer 2",
                    BiographyURL = "http://Producer2/bio",
                    PictureURL = "http://Producer2/photo2.jpg"
                }
            };

            return producers;
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Name = "Race",
                    Description = "This is the Race movie description",
                    MovieCategory = MovieCategory.Action,
                    ProducerId = 1,
                    AgeCategory = AgeCategory.ParentalGuidance,
                    Price = 23.45M,
                    MovieLength = 123,
                    ImageURL = "http://race/imag1.jpg"


                },

                new Movie()
                {
                    Name = "Ghost",
                    Description = "This is the Ghost movie description",
                    MovieCategory = MovieCategory.Horror,
                    ProducerId = 1,
                    AgeCategory = AgeCategory.ParentalGuidance,
                    Price = 33.45M,
                    MovieLength = 244,
                    ImageURL = "http://ghost/imag1.jpg"


                }
            };

            return movies;
        }
    }
}
