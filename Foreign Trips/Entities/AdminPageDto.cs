using Foreign_Trips.Model;

namespace Foreign_Trips.Entities
{
    public class AdminPageDto
    {
        public int Count { get; set; }

        public List<InternationalAdminTbl> Data { get; set; }
    }
}
