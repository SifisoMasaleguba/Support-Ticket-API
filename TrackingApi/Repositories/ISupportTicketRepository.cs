using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingApi.Models;

namespace TrackingApi.Repositories
{
    public interface ISupportTicketRepository
    {
        Task<IEnumerable<SupportTicket>> Get();
        Task<SupportTicket> Get(int id);
        Task<SupportTicket> Create(SupportTicket supportTicket);
        Task Update(SupportTicket supportTicket);
        Task Delete(int id);
    }
}
