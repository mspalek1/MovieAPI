using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Data;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Pages;
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

        public PageResult<Movie> GetPagedWithQuery(MovieQuery query)
        {
        
            bool isSuccess = Enum.TryParse<MovieCategory>(query.SearchPhrase, out var movieCategory);

            var baseQuery = _dbContext
                .Movie
                .Where(r => query.SearchPhrase == null ||
                            r.Name.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                            (isSuccess && r.MovieCategory.HasFlag(movieCategory)));

            var movie = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();
            var result = new PageResult<Movie>(movie, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
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
