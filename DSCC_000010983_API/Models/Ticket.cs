﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DSCC_000010983_API.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public int Duration { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}