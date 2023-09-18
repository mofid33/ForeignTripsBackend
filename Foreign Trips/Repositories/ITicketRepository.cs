using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface ITicketRepository
    {
        Task<bool> TicketExistsAsync(int ticketId);
        Task<IEnumerable<TicketTbl?>> GetTickets(long agentId);
        Task<TicketTbl?> GetTicketAsync(int ticketId);
        Task<IEnumerable<TicketDetailsTbl?>> GetSubTickets(int ticketId);
        Task<TicketTbl?> InsertTicket(TicketTbl ticket);
        Task<TicketDetailsTbl?> InsertSubTicket(TicketDetailsTbl ticket);
    }
}
