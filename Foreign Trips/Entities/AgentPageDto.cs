using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Foreign_Trips.Model;

namespace Foreign_Trips.Entities
{
    public class AgentPageDto
    {

        public int Count { get; set; }

        public List<AgentTbl> Data { get; set; }

    }
}
