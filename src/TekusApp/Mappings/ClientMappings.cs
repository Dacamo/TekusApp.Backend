using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekusApp.Commands;
using TekusApp.Domain.Models;

namespace TekusApp.Mappings
{
    public class ClientMappings: Profile
    {
        public ClientMappings()
        {
            CreateMap<UpdateClient, Client>();
        }
    }
}
