using FamiliesApp.Domain.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public class ServiceBehavior : IServiceBehavior
    {
        private readonly IDataStorage<Service> _serviceRepository;

        public ServiceBehavior(IDataStorage<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task CreateAsync(Service service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            await _serviceRepository.InsertAsync(service);
        }

        public async Task DeleteAsync(Service service)
        {
            await _serviceRepository.DeleteAsync(service);
        }

        public async  Task<List<Service>> GetAllAsync()
        {
            return await _serviceRepository.FindAllAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _serviceRepository.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Service service)
        {
            await _serviceRepository.UpdateAsync(service);
        }

        public async Task<List<Service>> GetByClientIdAsync(int id)
        {
            return await _serviceRepository.FindAsync(client => client.ClientId == id);
        }

        public async Task<int> CountAsync()
        {
            return await _serviceRepository.Count();
        }

    }
}
