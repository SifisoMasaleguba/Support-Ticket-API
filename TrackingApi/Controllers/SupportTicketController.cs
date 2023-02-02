using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingApi.Repositories;
using TrackingApi.Models;

namespace TrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        private readonly ISupportTicketRepository _supportTicketRepository;
        public SupportTicketController(ISupportTicketRepository supportTicketRepository)           
        {
            _supportTicketRepository = supportTicketRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SupportTicket>> GetSupportTickets()
        {
            return await _supportTicketRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicket>> GetSupportTickets(int id)
        {
            return await _supportTicketRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<SupportTicket>> PostBooks([FromBody] SupportTicket supportTicket)
        {
            var newSupportTicket = await _supportTicketRepository.Create(supportTicket);
            return CreatedAtAction(nameof(GetSupportTickets), new { id = newSupportTicket.Id }, newSupportTicket);
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] SupportTicket supportTicket)
        {
            if (id != supportTicket.Id)
            {
                return BadRequest();
            }

            await _supportTicketRepository.Update(supportTicket);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var supportTicketToDelete = await _supportTicketRepository.Get(id);
            if (supportTicketToDelete == null)
                return NotFound();

            await _supportTicketRepository.Delete(supportTicketToDelete.Id);
            return NoContent();
        }
    }
}
