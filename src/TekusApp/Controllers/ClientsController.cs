
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TekusApp.Domain.Behaviors;
using TekusApp.Domain.Models;
using AutoMapper;
using TekusApp.Commands;
using System;
using System.Linq;

namespace TekusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController: ControllerBase
    {
        private readonly IClientBehavior _clientBehavior;
        private readonly IMapper _mapper;

        public ClientsController(IClientBehavior clientBehavior, IMapper mapper)
        {
            _clientBehavior = clientBehavior;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Client>> CreateAsync([FromBody]CreateClient createClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = _mapper.Map<Client>(createClient);
            await _clientBehavior.CreateAsync(client);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = client.Id }, client);
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
                return NotFound();
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
                return NotFound();
            }
            _mapper.Map(updateClient, client);
            await _clientBehavior.UpdateAsync(client);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingClient = await _clientBehavior.GetByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            await _clientBehavior.DeleteAsync(existingClient);
            return NoContent();
        }

        [HttpGet("Count")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> CountAsync()
        {
            return await _clientBehavior.CountAsync();
        }

        [HttpGet("pagination/{page}")]
        [ProducesResponseType(200)]
        public async Task<List<Client>> GetByRangeAsync(int page)
        {
            return await _clientBehavior.GetByRangeAsync(page);
        }
    }

}
