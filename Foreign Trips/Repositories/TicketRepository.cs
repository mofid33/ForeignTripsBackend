using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
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

        public async Task<IEnumerable<TicketDetailsTbl?>> GetSubTickets(int ticketId)
        {
            return await _context.TicketDetailsTbl.Include(t => t.Ticket)
                .Include(t => t.Ticket.TicketStatus)
                .Include(t => t.Ticket.Agent)
                .Where(t => t.TicketId == ticketId).ToListAsync();
        }

        public async Task<TicketTbl?> GetTicketAsync(int ticketId)
        {
            return await _context.TicketTbl
                .Include(t => t.TicketStatus)
                .Where(t => t.TicketId == ticketId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TicketTbl?>> GetTickets(long agentId)
        {
            return await _context.TicketTbl
               .Include(t => t.TicketStatus)
               .Where(t=>t.AgentId== agentId)
               .ToListAsync();
        }

        public async Task<TicketDetailsTbl?> InsertSubTicket(TicketDetailsTbl ticket)
        {
            try
            {

                TicketDetailsTbl ttbl = new TicketDetailsTbl();
                ttbl.Message = ticket.Message;
                ttbl.IsAdmin = ticket.IsAdmin;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);


                string date = persianDateTime.ToString().Substring(0, 10);
                ttbl.RegisterDate = date;
                ttbl.RegisterTime = DateTime.Now.ToShortTimeString();
                ttbl.TicketId = ticket.TicketId;

                await _context.TicketDetailsTbl.AddAsync(ttbl);
                await _context.SaveChangesAsync();
                var tt=     await _context.TicketTbl.Where(t => t.TicketId == ticket.TicketId).FirstOrDefaultAsync();
                tt.TicketStatusId = ttbl.IsAdmin? 2:1;
                await _context.SaveChangesAsync();

                return ticket;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }


        public async Task<TicketTbl?> InsertTicket(TicketTbl ticket)
        {
            try
            {

                TicketTbl ttbl = new TicketTbl();
                ttbl.AgentId = ticket.AgentId;
                ttbl.TicketStatusId = 1;
                byte[] bytes2;
                Random rnd = new Random();
                int num = rnd.Next(10000, 100000);
                ttbl.TicketNumber = num.ToString();
                ttbl.Subject = ticket.Subject;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);


                string date = persianDateTime.ToString().Substring(0, 10);
                ttbl.RegisterDate = date;
                ttbl.RegisterTime = DateTime.Now.ToShortTimeString(); 
                ttbl.LatestUpdate = date;
                await _context.TicketTbl.AddAsync(ttbl);
                await _context.SaveChangesAsync();



                return ttbl;

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
