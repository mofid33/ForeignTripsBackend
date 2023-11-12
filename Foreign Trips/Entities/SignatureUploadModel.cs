namespace Foreign_Trips.Entities
{
    public class SignatureUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public int RequestId { get; set; }
        public string Signatory { get; set; } = null!;
        public int? FileTypeId { get; set; }
    }
}
