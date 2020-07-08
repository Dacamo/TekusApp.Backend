using AutoMapper;
using TekusApp.Commands;
using TekusApp.Domain.Models;

namespace TekusApp.Mappings
{
    public class ClientMappings: Profile
    {
        public ClientMappings()
        {
            CreateMap<UpdateClient, Client>();
            CreateMap<CreateClient, Client>();
        }
    }
}
