using CW_DSCC_10983_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CW_DSCC_10983_MVC.Controllers
{
    public class TicketController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:44398/api");
        private readonly HttpClient _httpClient;

        public TicketController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Ticket> ticketlist = new List<Ticket>();
            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44398/api/TicketsContoller/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ticketlist = JsonConvert.DeserializeObject<List<Ticket>>(data);
            }
            return View(ticketlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            try
            {
                string data = JsonConvert.SerializeObject(ticket);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync("https://localhost:44398/api/TicketsContoller/Post", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Ticket Created";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
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
                Ticket ticket = new Ticket();
                HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44398/api/TicketsContoller/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    ticket = JsonConvert.DeserializeObject<Ticket>(data);
                }
                return View(ticket);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Ticket ticket)
        {
            try
            {
                string data = JsonConvert.SerializeObject(ticket);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync("https://localhost:44398/api/TicketsContoller/Put", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Ticket Edited";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View(ticket);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Ticket ticket = new Ticket();
                HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44398/api/TicketsContoller/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    ticket = JsonConvert.DeserializeObject<Ticket>(data);
                }
                return View(ticket);
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
                HttpResponseMessage response = _httpClient.DeleteAsync("https://localhost:44398/api/TicketsContoller/Delete/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Ticket Deleted";
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
