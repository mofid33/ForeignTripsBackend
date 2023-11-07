using Foreign_Trips.Model;

namespace Foreign_Trips.Entities
{
    public class MessagePageDto
    {
        public int Count { get; set; }

        public List<MessageTbl> Data { get; set; }
    }
}
