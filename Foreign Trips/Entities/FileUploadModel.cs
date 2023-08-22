using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Foreign_Trips.Entities
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
         public long? AgentId { get; set; }
         public int? FileTypeId { get; set; }
            
        
    }
}
