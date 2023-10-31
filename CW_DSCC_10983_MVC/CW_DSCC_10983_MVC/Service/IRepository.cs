using CW_DSCC_10983_MVC.Models;
using Microsoft.Extensions.Hosting;

namespace CW_DSCC_10983_MVC.Service
{
    public interface IRepository
    {
        // For Customer
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Ticket>> GetTicketByCustomerId(int id);
        Task DeleteCustomerById(int id);

        // For Ticket
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(int id);
        Task UpdateCustomer(Customer author);
        Task DeleteTicketById(int id);
    }
}
