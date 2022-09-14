using System;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public class ServiceManagerRepository : IServiceManagerRepository
    {
        private readonly Lazy<IMovieRepository> _lazyMovieRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly MovieDBContext _context;
        public ServiceManagerRepository(MovieDBContext dbContext)
        {
            _lazyMovieRepository = new Lazy<IMovieRepository>(() => new MovieRepository(dbContext));
            _producerRepository = new ProducerRepository(dbContext);
            _context = dbContext;
        }

        public IProducerRepository ProducerRepository
        {
            get { return _producerRepository; }
        }

        public IMovieRepository MovieRepository
        {
            get { return _lazyMovieRepository.Value; }
        }

        public MovieDBContext GetMovieDbContext()
        {
            return _context;

        }
    }
}
