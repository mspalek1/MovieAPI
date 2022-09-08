using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
    }
}
