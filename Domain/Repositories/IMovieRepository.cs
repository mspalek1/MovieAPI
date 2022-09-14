using Domain.Entities;
using System.Collections.Generic;
using Domain.Queries;
using Domain.Pages;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        PageResult<Movie> GetPagedWithQuery(MovieQuery query);
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);

        void Create(Movie movie);
    }
}
