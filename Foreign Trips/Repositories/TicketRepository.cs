using Foreign_Trips.DbContexts;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AgentDbContext _context;
        public TicketRepository(AgentDbContext context)

        {
            _context = context ?? throw new ArgumentException(nameof(context));

        }

        //public async Task<IEnumerable<TicketDetailsTbl?>> GetSubTickets(int ticketId)
        //{
        //    return await _context.TicketDetailsTbl.Include(t => t.Ticket)
        //        .Include(t => t.Ticket.TicketStatus)
        //        .Include(t => t.Ticket.Agent)
        //        .Where(t => t.TicketId == ticketId).ToListAsync();
        //}

        public async Task<TicketTbl?> GetTicketAsync(int ticketId)
        {
            return await _context.TicketTbl
                .Include(t => t.TicketStatus)
                .Where(t => t.TicketId == ticketId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TicketTbl?>> GetTickets()
        {
            return await _context.TicketTbl
               .Include(t => t.TicketStatus)
               .ToListAsync();
        }

        //public async Task<TicketDetailsTbl?> InsertSubTicket(TicketDetailsTbl ticket)
        //{
        //    try
        //    {

        //        var exp = await _context.TicketDetailsTbl.AddAsync(ticket);
        //        await _context.SaveChangesAsync();
        //        var ticketPar = await GetTicket(ticket.TicketId);
        //        ticketPar.TicketStatusId = 2;
        //        await _context.SaveChangesAsync();

        //        return ticket;

        //    }

        //    catch (System.Exception ex)
        //    {
        //        return null;

        //    }
        //}


        public async Task<TicketTbl?> InsertTicket(TicketTbl ticket)
        {
            try
            {

                var exp = await _context.TicketTbl.AddAsync(ticket);
                await _context.SaveChangesAsync();


                return ticket;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<bool> TicketExistsAsync(int ticketId)
        {
            return await _context.TicketTbl.AnyAsync(t => t.TicketId == ticketId);
        }
    }
}
