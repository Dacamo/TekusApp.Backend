using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public interface IServiceCountryBehavior
    {
        Task CreateAsync(ServiceCountry serviceCountry);
        Task DeleteAsync(ServiceCountry serviceCountry);
        Task<List<ServiceCountry>> GetAllByServiceIdAsync(int id);
        Task<ServiceCountry> GetByIdAsync(int id);
    }
}
