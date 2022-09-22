using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AccountAsyncRepository : BaseAsyncRepository<User> ,IAsyncAccountRepository
    {
        public AccountAsyncRepository(MovieDBContext dbContext) : base(dbContext)
        {
           
        }
        public async Task<User> GetUserByEmailWithRoleAsync(string email)
        {
            return await _dbContext.Users
                .Include(u=>u.Role)
                .FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

    }
}
