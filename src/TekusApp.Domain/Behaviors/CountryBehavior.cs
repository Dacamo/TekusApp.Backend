using FamiliesApp.Domain.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public class CountryBehavior : ICountryBehavior
    {
        private readonly IDataStorage<Country> _countryRepository;

        public CountryBehavior(IDataStorage<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _countryRepository.FindAllAsync();
        }
    }
}
