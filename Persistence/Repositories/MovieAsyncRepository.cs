using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Pages;
using Domain.Queries;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public sealed class MovieAsyncRepository : BaseAsyncRepository<Movie>, IMovieAsyncRepository
    {
        public MovieAsyncRepository(MovieDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<PageResult<Movie>> GetPagedAsyncWithQuery(MovieQuery query)
        {
            bool isSuccess = Enum.TryParse<MovieCategory>(query.SearchPhrase, out var movieCategory);

            var baseQuery = await _dbContext
                .Movie
                .Where(r => query.SearchPhrase == null ||
                            r.Name.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                            (isSuccess && r.MovieCategory.HasFlag(movieCategory)))
                            .ToListAsync();

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnSelector = new Dictionary<string, Func<Movie, object>>
                {
                    { nameof(Movie.Name), r => r.Name },
                    { nameof(Movie.Description), r => r.Description },
                    { nameof(Movie.MovieLength), r => r.MovieLength }
                };

                var selectedColumn = columnSelector[query.SortBy];

                baseQuery = query.SortDirection == ListSortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn).ToList()
                    : baseQuery.OrderByDescending(selectedColumn).ToList();
            }

            var movie = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();
            var result = new PageResult<Movie>(movie, totalItemsCount, query.PageSize, query.PageNumber);


            return result;
        }
    }
}
