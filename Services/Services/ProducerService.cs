using Domain.Repositories;
using Services.Interfaces;

namespace Services.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IServiceManagerRepository _managerRepository;

        public ProducerService(IServiceManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
    }
}
