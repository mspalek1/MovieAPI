using Domain.Repositories;

namespace Persistence.Repositories
{
    internal sealed class ProducerRepository : IProducerRepository
    {
        private readonly MovieDBContext _dbContext;

        public ProducerRepository(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
