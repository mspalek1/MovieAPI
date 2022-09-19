using System;
using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MovieDBContext _dbContext;
        public AccountRepository(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterAccount(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
