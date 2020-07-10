using FamiliesApp.Domain.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public class ServiceCountryBehavior : IServiceCountryBehavior
    {
        private readonly IDataStorage<ServiceCountry> _serviceCountryRepository;

        public ServiceCountryBehavior(IDataStorage<ServiceCountry> serviceCountry)
        {
            _serviceCountryRepository = serviceCountry;
        }


        public async Task CreateAsync(ServiceCountry serviceCountry)
        {
            if(serviceCountry == null)
            {
                throw new ArgumentNullException(nameof(serviceCountry));
            }

            await _serviceCountryRepository.InsertAsync(serviceCountry);
        }

        public async Task DeleteAsync(ServiceCountry serviceCountry)
        {
            await _serviceCountryRepository.DeleteAsync(serviceCountry);
        }

        public async Task<List<ServiceCountry>> GetAllByServiceIdAsync(int serviceId)
        {
            return await _serviceCountryRepository.FindAsync(i => i.ServiceId == serviceId, includeProperties: "Country");
        }

        public async Task<ServiceCountry> GetByIdAsync(int id)
        {
            return await _serviceCountryRepository.FirstOrDefaultAsync(i => i.Id == id);
        }
   
    }
}
