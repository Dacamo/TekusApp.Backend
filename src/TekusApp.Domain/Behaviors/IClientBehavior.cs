using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public interface IClientBehavior
    {
        Task CreateAsync(Client client);
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task DeleteAsync(Client client);
        Task UpdateAsync(Client client);
        Task<int> CountAsync();
        Task<List<Client>> GetByRangeAsync(int page);
 
    }
}
