using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface ITicketRepository
    {
        Task<bool> TicketExistsAsync(int ticketId);
        Task<TicketPageDto> GetTickets(int page, int pageSize, string search);
        Task<IEnumerable<TicketTbl?>> GetTicketExpert(int ExpertId);
        Task<IEnumerable<TicketTbl?>> GetTicketAdmi(int AdminId);
        Task<IEnumerable<TicketTbl?>> GetTicketMainAdmin();
        Task<TicketTbl?> GetTicketAsync(int ticketId);
        Task<TicketDetailsTbl?> InsertSubTicketExpertToAgent(TicketDetailsDto ticket);
        Task<TicketDetailsTbl?> InsertSubTicketExpertAdmin(TicketDetailsTbl ticket);
        Task<TicketTbl?> InsertTicketExpertToAdmin(TicketTbl ticket);
        Task<IEnumerable<TicketDetailsTbl?>> GetSubTickets(int ticketId);
        Task<TicketTbl?> InsertTicket(TicketTbl ticket);
        Task<TicketDetailsTbl?> InsertSubTicket(TicketDetailsTbl ticket);
    }
}
