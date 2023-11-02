using CW_DSCC_10983_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CW_DSCC_10983_MVC.Controllers
{
    public class CustomerController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:44398/api");
        private readonly HttpClient _httpClient;

        public CustomerController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customerlist = new List<Customer>();
            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44398/api/Customers/GetCustomers").Result;
            if(response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customerlist = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
            return View(customerlist);
        }
    }
}
