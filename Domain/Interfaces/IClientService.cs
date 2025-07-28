using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientService
    {
        public Task<List<Client>> GetAllAsync();
        public Task<Client> GetByIdAsync(int id);
        public Task<bool> AddAsync(Client client);
        public Task<bool> UpdateAsync(Client client);
        public Task<bool> RemoveByIdAsync(int id);
    }
}
