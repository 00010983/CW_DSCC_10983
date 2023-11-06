using CW_DSCC_10983_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44398/api/Customer/Get").Result;
            if(response.IsSuccessStatusCode) 
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customerlist = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
            return View(customerlist);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer) 
        {   
            try
            {
                string data = JsonConvert.SerializeObject(customer);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync("https://localhost:44398/api/Customer/Post", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Customer Created";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception  ex) 
            {
                TempData["errorMessage"] = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            try
            {
                Customer customer = new Customer();
                HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44398/api/Customer/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(data);
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Customer customer) 
        {
            try
            {
                string data = JsonConvert.SerializeObject(customer);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync($"https://localhost:44398/api/Customer/Put", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Customer Edited";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            try
            {
                Customer customer = new Customer();
                HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44398/api/Customer/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(data);
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync("https://localhost:44398/api/Customer/Delete/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Customer Deleted";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

    }
}
