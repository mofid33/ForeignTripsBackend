using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using NPOI.SS.Formula.Functions;

namespace Foreign_Trips.Repositories
{
    public interface ITicketRepository
    {
        Task<bool> TicketExistsAsync(int ticketId);
        Task<TicketPageDto> GetTickets(int page, int pageSize, string search,int agentId);
        Task<TicketPageDto> GetTicketExpert(int page, int pageSize, string search, int ExpertId);
        Task<TicketPageDto> GetTicketAdmin(int page, int pageSize, string search, int AdminId);
        Task<TicketPageDto> GetTicketMainAdmin(int page, int pageSize, string search, int MainAdminId);
        Task<TicketTbl?> GetTicketAsync(int ticketId);
        Task<TicketDetailsTbl?> InsertSubTicketExpertToAgent(TicketDetailsDto ticket);
        Task<TicketDetailsTbl?> InsertSubTicketExpertAdmin(TicketDetailsTbl ticket);
        Task<TicketTbl?> InsertTicketExpertToAdmin(TicketTbl ticket);
        Task<IEnumerable<TicketDetailsTbl?>> GetSubTickets(int ticketId);
        Task<TicketTbl?> InsertTicket(TicketTbl ticket);
        Task<TicketDetailsTbl?> InsertSubTicket(TicketDetailsTbl ticket);
    }
}
