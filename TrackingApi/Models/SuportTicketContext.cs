using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingApi.Models
{
    public class SuportTicketContext : DbContext
    {
        public SuportTicketContext(DbContextOptions<SuportTicketContext> options) : base(options) {
            Database.EnsureCreated();        
        }
        public DbSet<SupportTicket> SupportTickets { get; set; }
    }
}
