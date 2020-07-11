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

            var existingServiceCountry = await _serviceCountryRepository.FirstOrDefaultAsync(c => c.CountryId == serviceCountry.CountryId && c.ServiceId == serviceCountry.ServiceId);

            if( existingServiceCountry != null)
            {
                throw new Exception("Ya se encuentra registrado en ese país");
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
        public async Task<List<ServicesByCountry>> GetQuantity()
        {
            var servicesCountries = await _serviceCountryRepository.FindAsync(includeProperties: "Country");

            var dictionary = new Dictionary<string, int>();

            foreach (var serviceCountry in servicesCountries)
            {
                if (!dictionary.ContainsKey(serviceCountry.Country.Name))
                {
                    dictionary.Add(serviceCountry.Country.Name, 1);
                }
                else
                {
                    dictionary[serviceCountry.Country.Name]++;
                }


            }
            var servicesByCountries = new List<ServicesByCountry>();
            foreach (var item in dictionary)
            {
                servicesByCountries.Add(new ServicesByCountry()
                {
                    Name = item.Key,
                    Quantity = item.Value
                }); ;
            }

            return servicesByCountries;

        }
    }
}
