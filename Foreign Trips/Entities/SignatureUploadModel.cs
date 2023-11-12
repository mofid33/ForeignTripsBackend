namespace Foreign_Trips.Entities
{
    public class SignatureUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public long? AdmintId { get; set; }
        public long? MainAdmintId { get; set; }
        public int? FileTypeId { get; set; }
    }
}
