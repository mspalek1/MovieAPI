using System;
using AutoMapper;
using Domain.Repositories;
using Services.Interfaces;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _lazyMovieService;
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;

        public ServiceManager(IServiceManagerRepository managerRepository, IMapper mapper)
        {
            _lazyMovieService = new Lazy<IMovieService>(() => new MovieService(managerRepository, mapper));
            _producerService = new ProducerService(managerRepository);
        }

        public IMovieService MovieService
        {
            get { return _lazyMovieService.Value; }
        }

        public IProducerService ProducerService
        {
            get { return _producerService; }
        }
    }
}
