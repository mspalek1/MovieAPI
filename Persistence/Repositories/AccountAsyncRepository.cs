using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class AccountAsyncRepository : BaseAsyncRepository<User> ,IAsyncAccountRepository
    {
        public AccountAsyncRepository(MovieDBContext dbContext) : base(dbContext)
        {
        }

    }
}
