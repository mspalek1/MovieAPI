using Domain.Entities;
using System.Collections.Generic;
using Domain.Queries;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetPagedWithQuery(MovieQuery query);
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);

        void Create(Movie movie);
    }
}
