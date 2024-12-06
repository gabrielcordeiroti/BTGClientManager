using BTGClientManager.Domain.Entities;

namespace BTGClientManager.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(int id);
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(int id);
    }
}
