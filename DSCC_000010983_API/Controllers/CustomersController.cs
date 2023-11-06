using DSCC_000010983_API.Data;
using DSCC_000010983_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSCC_000010983_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var customers = _context.Customers.ToList();
                if (customers.Count == 0)
                {
                    return NotFound("Customers not available");
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound("Customer not found");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Customer customer) 
        {
            try
            {
                _context.Add(customer);
                _context.SaveChanges();
                return Ok("Customer Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public IActionResult Put(Customer model)
        {

            try
            {
                var customer = _context.Customers.Find(model.CustomerId);
                if (customer == null)
                {
                    return NotFound("Customer not found with id " + model.CustomerId);
                }
                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.Address = model.Address;
                customer.PhoneNumber = model.PhoneNumber;
                customer.DateOfBirth = model.DateOfBirth;
                _context.SaveChanges();
                return Ok("Customer updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
 
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound($"Customer not found with id {id}");
                }
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return Ok("Cusomer deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
