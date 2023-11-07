using Azure.Core;
using Foreign_Trips.DbContexts;
using Foreign_Trips.Entities;
using Foreign_Trips.Model;
using Foreign_Trips.Utility;
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
        public async Task<MessagePageDto> GetMessage(int page, int pageSize, string search)
        {
            try
            {
                var messages = await _context.MessageTbl
                .Include(t => t.Agent)
                .Include(t => t.ReciverMessage)
                .Include(t => t.DispatcherSelection)
                .Include(t => t.ExpertSelection)
                .Where(t => (search != "" && search != null) ? (t.Agent.AgentName.Contains(search) || t.Agent.AgentFamily.Contains(search)) : t.Agent.AgentName != null)


                    .ToListAsync();

                var ss = await PaginatedList<MessageTbl>.CreateAsync(messages, page, pageSize);
                return new MessagePageDto
                {
                    Count = messages.Count(),
                    Data = ss

                };
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<MessageTbl?> GetMessageAsync(int messageId)
        {
            try
            {
                return await _context.MessageTbl.Where(c => c.MessageId == messageId).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
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
                DateTime dt = new DateTime();
                PersianDateTime persianDateTime = new PersianDateTime(DateTime.Now);
                string date = persianDateTime.ToString().Substring(0, 10);

                Mtbl.RegisterTime = DateTime.Now.ToShortTimeString();
                Mtbl.RegisterDate = date;




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
