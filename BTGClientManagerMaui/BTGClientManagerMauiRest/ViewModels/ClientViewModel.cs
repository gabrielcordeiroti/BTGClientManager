using BTGClientManagerMauiRest.Models;
using BTGClientManagerMauiRest.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BTGClientManagerMauiRest.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => SetProperty(ref _clients, value);
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set => SetProperty(ref _selectedClient, value);
        }

        public ICommand LoadClientsCommand { get; }
        public ICommand AddClientCommand { get; }
        public ICommand UpdateClientCommand { get; }
        public ICommand DeleteClientCommand { get; }

        private readonly ClientService _clientService;

        public ClientViewModel(ClientService clientService)
        {
            _clientService = clientService;
            Clients = new ObservableCollection<Client>();

            LoadClientsCommand = new Command(async () => await LoadClientsAsync());
            AddClientCommand = new Command(async () => await AddClientAsync());
            UpdateClientCommand = new Command(async () => await UpdateClientAsync());
            DeleteClientCommand = new Command(async () => await DeleteClientAsync());
        }

        private async Task LoadClientsAsync()
        {
            var clients = await _clientService.GetClientesAsync();
            Clients.Clear();
            foreach (var client in clients)
                Clients.Add(client);
        }

        private async Task AddClientAsync()
        {
            if (SelectedClient == null)
                return;

            await _clientService.AddClienteAsync(SelectedClient);
            await LoadClientsAsync();
            SelectedClient = null; 
        }

        private async Task UpdateClientAsync()
        {
            if (SelectedClient == null)
                return;

            await _clientService.UpdateClienteAsync(SelectedClient);
            await LoadClientsAsync();
            SelectedClient = null; 
        }

        private async Task DeleteClientAsync()
        {
            if (SelectedClient == null)
                return;

            await _clientService.DeleteClienteAsync(SelectedClient.Id);
            await LoadClientsAsync();
            SelectedClient = null; 
        }
    }
}
