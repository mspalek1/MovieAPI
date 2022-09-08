﻿using Domain.Repositories;
using Services.Interfaces;

namespace Services
{
    internal class MovieService : IMovieService
    {
        private readonly IServiceManagerRepository _managerRepository;

        public MovieService(IServiceManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
    }
}
