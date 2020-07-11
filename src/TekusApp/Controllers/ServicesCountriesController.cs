using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekusApp.Commands;
using TekusApp.Domain.Behaviors;
using TekusApp.Domain.Models;

namespace TekusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesCountriesController : ControllerBase
    {
        private readonly IServiceCountryBehavior _serviceCountryBehavior;
        private readonly IMapper _mapper;

        public ServicesCountriesController(IServiceCountryBehavior serviceCountryBehavior, IMapper mapper)
        {
            _serviceCountryBehavior = serviceCountryBehavior;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task CreateAsync(CreateServiceCountry createServiceCountry)
        {
            var serviceCountry = _mapper.Map<ServiceCountry>(createServiceCountry);
            await _serviceCountryBehavior.CreateAsync(serviceCountry);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingServiceCountry = await _serviceCountryBehavior.GetByIdAsync(id);
            if (existingServiceCountry == null)
            {
                return new NotFoundResult();
            }

            await _serviceCountryBehavior.DeleteAsync(existingServiceCountry);
            return new NoContentResult();
        }

        [HttpGet("serviceId/{serviceId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<List<ServiceCountry>> GetByClientIdAync(int serviceId)
        {
            return await _serviceCountryBehavior.GetAllByServiceIdAsync(serviceId);
        }

        [HttpGet("count")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<List<ServicesByCountry>> CountServicesByCountry()
        {
            return await _serviceCountryBehavior.GetQuantity();
        }

    }
}
