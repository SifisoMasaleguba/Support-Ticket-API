using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingApi.Models;

namespace TrackingApi.Repositories
{
    public class SupportTicketRepository : ISupportTicketRepository
    {
        private readonly SuportTicketContext _context;
        public SupportTicketRepository(SuportTicketContext context) 
        {
            _context = context;
        }
        public async Task<SupportTicket> Create(SupportTicket supportTicket)
        {
            _context.SupportTickets.Add(supportTicket);
            await _context.SaveChangesAsync();
            return supportTicket;
        }

        public async Task Delete(int id)
        {
            var supportTicket = await _context.SupportTickets.FindAsync(id);
            _context.SupportTickets.Remove(supportTicket);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupportTicket>> Get()
        {
            return await _context.SupportTickets.ToListAsync();
        }

        public async Task<SupportTicket> Get(int id)
        {
            return await _context.SupportTickets.FindAsync(id);
        }

        public async Task Update(SupportTicket supportTicket)
        {
            _context.Entry(supportTicket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
