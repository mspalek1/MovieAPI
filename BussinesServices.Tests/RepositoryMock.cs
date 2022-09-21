using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Data;
using Domain.Entities;
using Domain.Pages;
using Domain.Queries;
using Domain.Repositories;
using Moq;
using NUnit.Framework;
using Services.Function.Movie.Queries.GetMovieList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services
{
    public static class RepositoryMock
    {
        public static Mock<IMovieAsyncRepository> GetMovieAsyncRepository()
        {
            var movies = GetMovies();
            var mockMovieAsyncRepository = new Mock<IMovieAsyncRepository>();

            mockMovieAsyncRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(movies);

            mockMovieAsyncRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    return movies.FirstOrDefault(m => m.Id == id);
                });

            mockMovieAsyncRepository.Setup(repo => repo.AddAsync(It.IsAny<Movie>())).ReturnsAsync(
                (Movie movie) =>
                {
                    movies.Add(movie);
                    return movie;
                });
            mockMovieAsyncRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Movie>()))
                .Callback(
                    (Movie entity) =>
                    {
                        movies.Remove(entity);
                    }
                );
            mockMovieAsyncRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Movie>()))
                .Callback(
                    (Movie movie) =>
                    {
                        movies.Remove(movie);
                        movies.Add(movie);
                    }
                );


            mockMovieAsyncRepository.Setup(repo => repo.GetPagedAsyncWithQuery(It.IsAny<MovieQuery>()))
                .ReturnsAsync((MovieQuery movieQuery) =>
                {
                    var matches = movies.Where(x => x.Name.Contains(movieQuery.SearchPhrase))
                        .Skip((movieQuery.PageNumber - 1) * movieQuery.PageSize).Take(movieQuery.PageSize).ToList();
                    
                    var totalItemsCount = matches.Count;
                    var result = new PageResult<Movie>(matches, totalItemsCount, movieQuery.PageSize,
                        movieQuery.PageNumber);
                    return result;
                });

            return mockMovieAsyncRepository;
        }

        private static List<Movie> GetMovies()
        {
            return
                new List<Movie>()
                {
                    new Movie()
                    {
                        Id = 1,
                        AgeCategory = AgeCategory.ParentalGuidance,
                        Description = "Descritpion1",
                        ImageURL = "http://Movie1",
                        MovieCategory = MovieCategory.Action,
                        MovieLength = 124,
                        Name = "Movie1"
                    },
                    new Movie()
                    {
                        Id = 2,
                        AgeCategory = AgeCategory.ParentalGuidance,
                        Description = "Descritpion2",
                        ImageURL = "http://Movie2",
                        MovieCategory = MovieCategory.Action,
                        MovieLength = 240,
                        Name = "Movie2"
                    }
                };
        }
    }
}
