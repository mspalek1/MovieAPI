using System.Threading.Tasks;
using Domain.Entities;
using Domain.Pages;
using Domain.Queries;

namespace Domain.Repositories
{
    public interface IMovieAsyncRepository : IAsyncRepository<Movie>
    {
        public Task<PageResult<Movie>> GetPagedAsyncWithQuery(MovieQuery query);
    }
}
