using Infrastructure.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace Application
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<List<Client>> GetAllAsync()
        {
            return _clientRepository.GetAllAsync();
        }
    }
}
