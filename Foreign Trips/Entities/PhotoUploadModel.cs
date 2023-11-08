using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class PhotoUploadModel
    {
        public IFormFile FileDetails { get; set; }
         public long? AgentId { get; set; }
         public int? FileTypeId { get; set; }
            
        
    }
}
