using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IServiceManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public MovieService(IServiceManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {
            var movie = _managerRepository.MovieRepository.GetAll();

            var movieDto = _mapper.Map<List<MovieDto>>(movie);

            return movieDto;
        }
        
        public ActionResult<IEnumerable<MovieDto>> GetPagedWithQuery(MovieQuery query)
        {
            var movie = _managerRepository.MovieRepository.GetPagedWithQuery(query);

            var movieDto = _mapper.Map<List<MovieDto>>(movie);

            return movieDto;
        }

        public ActionResult<MovieDto> GetById(int id)
        {
            var movie = _managerRepository.MovieRepository.GetById(id);

            var movieDto = _mapper.Map<MovieDto>(movie);

            return movieDto;
        }

        public int Create(CreateMovieDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            _managerRepository.MovieRepository.Create(movie);
            return movie.Id;
        }
    }
}
