using Foreign_Trips.Model;

namespace Foreign_Trips.Entities
{
    public class RequestPageDto
    {
        public int Count { get; set; }

        public List<RequestTbl> Data { get; set; }

    }
}
