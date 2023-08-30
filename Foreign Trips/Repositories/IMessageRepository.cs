using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IMessageRepository
    {
        Task<bool> MessageExistsAsync(int messageId);
        Task<IEnumerable<MessageTbl?>> GetMessage();
        Task<MessageTbl?> GetMessageAsync(int messageId);
        Task<MessageTbl?> InsertMessage(MessageTbl message);
    }
}
