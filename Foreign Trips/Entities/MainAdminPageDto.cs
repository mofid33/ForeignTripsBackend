using Foreign_Trips.Model;

namespace Foreign_Trips.Entities
{
    public class MainAdminPageDto
    {
        public int Count { get; set; }

        public List<MainAdminTbl> Data { get; set; }
    }
}
