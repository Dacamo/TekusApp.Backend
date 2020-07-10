using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public interface IServiceBehavior
    {
        Task CreateAsync(Service service);
        Task<List<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task DeleteAsync(Service service);
        Task UpdateAsync(Service service);
        Task<List<Service>> GetByClientIdAsync(int id);
        Task<int> CountAsync();

    }
}
