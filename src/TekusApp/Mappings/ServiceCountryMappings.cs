using AutoMapper;
using TekusApp.Commands;
using TekusApp.Domain.Models;

namespace TekusApp.Mappings
{
    public class ServiceCountryMappings: Profile
    {
        public ServiceCountryMappings()
        {
            CreateMap<CreateServiceCountry, ServiceCountry>();
        }
    }
}
