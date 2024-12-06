using BTGClientManager.Domain.Entities;
using BTGClientManager.Domain.Interfaces;
using BTGClientManager.Infrastructure.Contexts;
using Dapper;

namespace BTGClientManager.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DapperContext _context;

        public ClientRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Client>("SELECT * FROM Clients");
        }

        public async Task<Client> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Client>(
                "SELECT * FROM Clients WHERE Id = @Id", new { Id = id });
        }

        public async Task Add(Client client)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(
                "INSERT INTO Clients (Name, Lastname, Age, Address) VALUES (@Name, @Lastname, @Age, @Address)",
                client);
        }

        public async Task Update(Client client)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(
                "UPDATE Clients SET Name = @Name, Lastname = @Lastname, Age = @Age, Address = @Address WHERE Id = @Id",
                client);
        }

        public async Task Delete(int id)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync("DELETE FROM Clients WHERE Id = @Id", new { Id = id });
        }
    }
}
