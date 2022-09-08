using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Contracts;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Services
{
    internal class MovieService : IMovieService
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
    }
}
