using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Foreign_Trips.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AgentDbContext _context;
        public MessageRepository(AgentDbContext context)

        {
            _context = context ?? throw new ArgumentException(nameof(context));

        }
        public async Task<IEnumerable<MessageTbl?>> GetMessage()
        {
            return await _context.MessageTbl.ToListAsync();
        }

        public async Task<MessageTbl?> GetMessageAsync(int messageId)
        {
            return await _context.MessageTbl.Where(c => c.MessageId == messageId).FirstOrDefaultAsync();
        }

        public async Task<MessageTbl?> InsertMessage(MessageTbl message)
        {
            try
            {
                MessageTbl Mtbl = new MessageTbl();
                Mtbl.MessageTopic = message.MessageTopic;
                Mtbl.MessageText = message.MessageText;
                Mtbl.ReciverMessageId = message.ReciverMessageId;
                Mtbl.SubmitTime = message.SubmitTime;
                Mtbl.DispatcherSelectionId = message.DispatcherSelectionId;
                Mtbl.AgentId = message.AgentId;
                Mtbl.ExpertSelectionId = message.ExpertSelectionId;
                Mtbl.RegisterDate = message.RegisterDate;
                Mtbl.RegisterTime = message.RegisterTime;




                await _context.MessageTbl.AddAsync(Mtbl);
                await _context.SaveChangesAsync();

                return message;


            }

            catch (System.Exception ex)
            {
                return null;

            }
        }
    

        public async Task<bool> MessageExistsAsync(int messageId)
        {
            return await _context.MessageTbl.AnyAsync(t => t.MessageId == messageId);
        }
    }
}
