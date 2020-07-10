using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TekusApp.Commands;
using TekusApp.Domain.Behaviors;
using TekusApp.Domain.Models;

namespace TekusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceBehavior _serviceBehavior;
        private readonly IMapper _mapper;

        public ServicesController(IServiceBehavior serviceBehavior, IMapper mapper)
        {
            _serviceBehavior = serviceBehavior;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task CreateAsync(CreateService createService)
        {
            var service = _mapper.Map<Service>(createService);
            await _serviceBehavior.CreateAsync(service);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<Service>> GetAllAsync()
        {
            return await _serviceBehavior.GetAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Service>> GetByIdAsync(int id)
        {
            var existingService = await _serviceBehavior.GetByIdAsync(id);
            if (existingService == null)
            {
                return new NotFoundResult();
            }
            return existingService;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateAsync(int id, UpdateService updateService)
        {
            var service = await _serviceBehavior.GetByIdAsync(id);
            if (service == null)
            {
                return new NotFoundResult();
            }
            _mapper.Map(updateService, service);
            await _serviceBehavior.UpdateAsync(service);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingService = await _serviceBehavior.GetByIdAsync(id);
            if (existingService == null)
            {
                return new NotFoundResult();
            }

            await _serviceBehavior.DeleteAsync(existingService);
            return new NoContentResult();
        }


        [HttpGet("clientId/{clientId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<List<Service>> GetByClientIdAync(int clientId)
        {
            return await _serviceBehavior.GetByClientIdAsync(clientId);
        }

        [HttpGet("Count")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> CountAsync()
        {
            return await _serviceBehavior.CountAsync();
        }


    }
}
