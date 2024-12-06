using BTGClientManager.Application.Interfaces;
using BTGClientManager.Domain.Entities;
using BTGClientManager.Domain.Interfaces;

namespace BTGClientManager.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAll() => await _repository.GetAll();

        public async Task<Client> GetById(int id) => await _repository.GetById(id);

        public async Task Add(Client client) => await _repository.Add(client);

        public async Task Update(Client client, int id)
        {
            var getClient = await GetById(id);
            if (getClient == null)
                throw new Exception("Cliente não encontrado");

            getClient.Name = client.Name;
            getClient.Lastname = client.Lastname;
            getClient.Age = client.Age;
            getClient.Address = client.Address;

            await _repository.Update(getClient);
        }

        public async Task Delete(int id) => await _repository.Delete(id);
    }
}
