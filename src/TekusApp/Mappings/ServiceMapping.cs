using AutoMapper;
using TekusApp.Commands;
using TekusApp.Domain.Models;

namespace TekusApp.Mappings
{
    public class ServiceMapping: Profile
    {
        public ServiceMapping()
        {
            CreateMap<CreateService, Service>();
            CreateMap<UpdateService, Service>();
        }
    }
}
