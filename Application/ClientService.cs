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

        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }
    }
}
