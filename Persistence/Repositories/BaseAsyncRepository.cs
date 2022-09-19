using System.Threading.Tasks;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class BaseAsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly MovieDBContext _dbContext;
        public BaseAsyncRepository(MovieDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
