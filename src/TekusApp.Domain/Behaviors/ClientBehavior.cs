using FamiliesApp.Domain.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Behaviors
{
    public class ClientBehavior : IClientBehavior
    {
        private readonly IDataStorage<Client> _clientRepository;

        public ClientBehavior(IDataStorage<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateAsync(Client client)
        {
            if(client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            await _clientRepository.InsertAsync(client);
        }

        public async Task DeleteAsync(Client client)
        {
            await _clientRepository.DeleteAsync(client);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _clientRepository.FindAllAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _clientRepository.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Client client)
        {
            await _clientRepository.UpdateAsync(client);
        }

        public async Task<int> CountAsync()
        {
            return await _clientRepository.Count();
        }

        public async Task<List<Client>> GetByRangeAsync(int page)
        {
            return await _clientRepository.FindAsync(skip: page * 4, take: 4);
        }

    }
}
