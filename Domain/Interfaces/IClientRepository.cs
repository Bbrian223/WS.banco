using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetAllAsync();
        public Task<Client> GetByIdAsync(int id);
        
    }
}
