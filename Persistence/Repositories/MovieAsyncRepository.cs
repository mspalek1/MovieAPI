using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class MovieAsyncRepository : BaseAsyncRepository<Movie>, IMovieAsyncRepository
    {
        public MovieAsyncRepository(MovieDBContext dbContext) : base(dbContext)
        {
        }
    }
}
