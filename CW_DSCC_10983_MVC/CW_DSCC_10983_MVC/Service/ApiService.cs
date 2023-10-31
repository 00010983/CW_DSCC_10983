using CW_DSCC_10983_MVC.Models;
using System.Text.Json;

namespace CW_DSCC_10983_MVC.Service
{
    public class ApiService : IRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"];
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        
        public async Task DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>(_apiBaseUrl + "customer");
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetTicketByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomer(Customer author)
        {
            throw new NotImplementedException();
        }
    }
}
