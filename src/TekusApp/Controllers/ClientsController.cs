
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TekusApp.Domain.Behaviors;
using TekusApp.Domain.Models;
using AutoMapper;
using TekusApp.Commands;

namespace TekusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController
    {
        private readonly IClientBehavior _clientBehavior;
        private readonly IMapper _mapper;

        public ClientsController(IClientBehavior clientBehavior, IMapper mapper)
        {
            _clientBehavior = clientBehavior;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task CreateAsync(CreateClient createClient)
        {
            var client = _mapper.Map<Client>(createClient);
            await _clientBehavior.CreateAsync(client);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientBehavior.GetAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Client>> GetByIdAsync(int id)
        {
            var existingClient = await _clientBehavior.GetByIdAsync(id);
            if (existingClient == null)
            {
                return new NotFoundResult();
            }
            return existingClient;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateAsync(int id, UpdateClient updateClient)
        {
            var client = await _clientBehavior.GetByIdAsync(id);
            if (client == null)
            {
                return new NotFoundResult();
            }
            _mapper.Map(updateClient, client);
            await _clientBehavior.UpdateAsync(client);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingClient = await _clientBehavior.GetByIdAsync(id);
            if (existingClient == null)
            {
                return new NotFoundResult();
            }

            await _clientBehavior.DeleteAsync(existingClient);
            return new NoContentResult();
        }
    }

}
