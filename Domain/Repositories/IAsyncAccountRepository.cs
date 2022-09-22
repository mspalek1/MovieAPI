using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAsyncAccountRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmailWithRoleAsync(string email);
    }
}
