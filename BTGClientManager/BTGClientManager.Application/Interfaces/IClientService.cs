using BTGClientManager.Domain.Entities;

namespace BTGClientManager.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(int id);
        Task Add(Client client);
        Task Update(Client client, int id);
        Task Delete(int id);
    }
}
