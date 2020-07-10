using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public interface ICountryBehavior
    {
        Task<List<Country>> GetAllAsync();
    }
}
