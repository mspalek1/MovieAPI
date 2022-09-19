using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAsyncRepository<T> where T: class 
    {
        Task<T> GetByIdAsync(int id);
    }
}
