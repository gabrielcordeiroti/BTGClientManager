using BTGClientManagerMauiRest.Models;
using System.Net.Http.Json;

namespace BTGClientManagerMauiRest.Service
{
    public class ClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7243/");//coloque a porta da api
        }

        public async Task<List<Client>> GetClientesAsync()
        {
            var response = await _httpClient.GetAsync("api/Client");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Client>>();
        }

        public async Task<Client> GetClienteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Client/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Client>();
        }

        public async Task AddClienteAsync(Client client)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Client", client);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateClienteAsync(Client client)
        {
            if (client == null || client.Id == 0)
                throw new ArgumentException("Cliente inválido para atualização.");

            var response = await _httpClient.PutAsJsonAsync($"api/Client/{client.Id}", client);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteClienteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido para exclusão.");

            var response = await _httpClient.DeleteAsync($"api/Client/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
