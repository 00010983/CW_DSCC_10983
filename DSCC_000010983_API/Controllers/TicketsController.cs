using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSCC_000010983_API.Data;
using DSCC_000010983_API.Models;

namespace DSCC_000010983_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketsContoller : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TicketsContoller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var tickets = _context.Tickets.ToList();
                if (tickets.Count == 0)
                {
                    return NotFound("Tickets not available");
                }
                return Ok(tickets);
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
                var ticket = _context.Tickets.Find(id);
                if (ticket == null)
                {
                    return NotFound("Ticket not found");
                }
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {
            try
            {
                _context.Add(ticket);
                _context.SaveChanges();
                return Ok("Ticket Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public IActionResult Put(Ticket model)
        {

            try
            {
                var ticket = _context.Tickets.Find(model.TicketId);
                if (ticket == null)
                {
                    return NotFound("Ticket not found with id " + model.TicketId);
                }
                ticket.Title = model.Title;
                ticket.Departure = model.Departure;
                ticket.Arrival = model.Arrival;
                ticket.Priority = model.Priority;
                ticket.DueDate = model.DueDate;
                ticket.Duration = model.Duration;
                ticket.CustomerId = model.CustomerId;
                _context.SaveChanges();
                return Ok("Ticket updated");
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
                var ticket = _context.Tickets.Find(id);
                if (ticket == null)
                {
                    return NotFound($"Ticket not found with id {id}");
                }
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
                return Ok("Ticket deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
