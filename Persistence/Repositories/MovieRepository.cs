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
    }
}
