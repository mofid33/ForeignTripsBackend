using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Utility;
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
        //کار نمیکنه
        public async Task<IEnumerable<TicketDetailsTbl?>> GetSubTickets(int ticketId)
        {
            try
            {
                return await _context.TicketDetailsTbl
                    .Include(t => t.Ticket)
                    .Include(t => t.Ticket.TicketStatus)
                    .Include(t => t.Ticket.Agent)
                    .Where(t => t.TicketId == ticketId).ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<TicketTbl?> GetTicketAsync(int ticketId)
        {
            try
            {
                return await _context.TicketTbl
                    .Include(t => t.TicketStatus)
                    .Where(t => t.TicketId == ticketId).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<TicketPageDto> GetTickets(int page, int pageSize, string search)
        {
            try
            {
                var ticket = await _context.TicketTbl
                .Include(t => t.TicketStatus)
                .Include(t => t.Agent)
                .Where(t => (search != "" && search != null) ? (t.Agent.AgentName.Contains(search) || t.Agent.AgentFamily.Contains(search)) : t.Agent.AgentName != null)


                .ToListAsync();

                var ss = await PaginatedList<TicketTbl>.CreateAsync(ticket, page, pageSize);
                return new TicketPageDto
                {
                    Count = ticket.Count(),
                    Data = ss

                };
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<TicketTbl?>> GetTicketExpert(int ExpertId)
        {
            try
            {
                return await _context.TicketTbl
                   .Include(t => t.TicketStatus)
                   .Where(t => t.InternationalExpertId == ExpertId || t.InternationalExpertId == null)
                   .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<TicketTbl?>> GetTicketAdmi(int AdminId)
        {
            try
            {
                return await _context.TicketTbl
                   .Include(t => t.TicketStatus)
                   .Where(t => t.AdminId == AdminId)
                   .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<TicketTbl?>> GetTicketMainAdmin()
        {
            try
            {
                return await _context.TicketTbl
                   .Include(t => t.TicketStatus)
                   .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<TicketDetailsTbl?> InsertSubTicket(TicketDetailsTbl ticket)
        {
            try
            {

                TicketDetailsTbl ttbl = new TicketDetailsTbl();
                ttbl.Message = ticket.Message;
                ttbl.IsAdmin = false;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);


                string date = persianDateTime.ToString().Substring(0, 10);
                ttbl.RegisterDate = date;
                ttbl.RegisterTime = DateTime.Now.ToShortTimeString();
                ttbl.TicketId = ticket.TicketId;

                await _context.TicketDetailsTbl.AddAsync(ttbl);
                await _context.SaveChangesAsync();
                var tt=     await _context.TicketTbl.Where(t => t.TicketId == ticket.TicketId).FirstOrDefaultAsync();
                tt.TicketStatusId = 1;
                await _context.SaveChangesAsync();

                return ticket;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<TicketDetailsTbl?> InsertSubTicketExpertToAgent(TicketDetailsDto ticket)
        {
            try
            {

                TicketDetailsTbl ttbl = new TicketDetailsTbl();
                ttbl.Message = ticket.Message;
                ttbl.IsAdmin = true;
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);


                string date = persianDateTime.ToString().Substring(0, 10);
                ttbl.RegisterDate = date;
                ttbl.RegisterTime = DateTime.Now.ToShortTimeString();
                ttbl.TicketId = ticket.TicketId;

                await _context.TicketDetailsTbl.AddAsync(ttbl);
                await _context.SaveChangesAsync();
                var tt = await _context.TicketTbl.Where(t => t.TicketId == ticket.TicketId).FirstOrDefaultAsync();
                tt.TicketStatusId = 2;
                tt.InternationalExpertId = ticket.InternationalExpertId;
                await _context.SaveChangesAsync();

                return ttbl;

            }

            catch (System.Exception ex)
            {
                return null;

            }
        }

        public async Task<TicketDetailsTbl?> InsertSubTicketExpertAdmin(TicketDetailsTbl ticket)
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
                var tt = await _context.TicketTbl.Where(t => t.TicketId == ticket.TicketId).FirstOrDefaultAsync();
                tt.TicketStatusId =ticket.IsAdmin?2: 1;
                
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

        public async Task<TicketTbl?> InsertTicketExpertToAdmin(TicketTbl ticket)
        {
            try
            {

                TicketTbl ttbl = new TicketTbl();
                ttbl.InternationalExpertId = ticket.InternationalExpertId;
                ttbl.AdminId = ticket.AdminId;
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
