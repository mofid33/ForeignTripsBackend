using Foreign_Trips.Model;

namespace Foreign_Trips.Entities
{
    public class TicketPageDto
    {
        public int Count { get; set; }

        public List<TicketTbl> Data { get; set; }
    }
}
