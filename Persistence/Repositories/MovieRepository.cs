using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Queries;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class MovieRepository : IMovieRepository
    {
        private readonly MovieDBContext _dbContext;

        public MovieRepository(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAll()
        {
            var movie = _dbContext.Movie.ToList();

            return movie;
        }

        public IEnumerable<Movie> GetPagedWithQuery(MovieQuery query)
        {
            var baseQuery = _dbContext
                .Movie
                .Where(r => query.SearchPhase == null ||
                            r.Name.ToLower().Contains(query.SearchPhase.ToLower()) ||
                            r.MovieCategory.Equals(query.SearchPhase));

            var movie = baseQuery.ToList();

            return movie;
        }

        public Movie GetById(int id)
        {
            var movie = _dbContext.Movie.FirstOrDefault(r => r.Id == id);

            if (movie is null)
            {
                throw new NotFoundException($"The movie with the identifier {id} was not found");
            }

            return movie;
        }

        public void Create(Movie movie)
        {
            _dbContext.Movie.Add(movie);
            _dbContext.SaveChanges();
        }
    }
}
