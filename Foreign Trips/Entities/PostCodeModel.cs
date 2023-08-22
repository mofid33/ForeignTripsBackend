namespace Foreign_Trips.Entities
{
    public class PostCodeModel
    {
        public int ClientBatchID { get; set; } = 0!;
        public List<PostCodes> Postcodes { get; set; }
    }
}
