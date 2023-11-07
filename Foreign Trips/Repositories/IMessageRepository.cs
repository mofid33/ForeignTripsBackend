using Foreign_Trips.Entities;
using Foreign_Trips.Model;

namespace Foreign_Trips.Repositories
{
    public interface IMessageRepository
    {
        Task<bool> MessageExistsAsync(int messageId);
        Task<MessagePageDto> GetMessage(int page, int pageSize, string search);
        Task<MessageTbl?> GetMessageAsync(int messageId);
        Task<MessageTbl?> InsertMessage(MessageTbl message);
    }
}
