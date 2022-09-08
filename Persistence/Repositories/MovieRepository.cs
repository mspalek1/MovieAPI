using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal sealed class MovieRepository : IMovieRepository
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
    }
}
