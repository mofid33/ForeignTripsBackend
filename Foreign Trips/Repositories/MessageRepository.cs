﻿using Azure.Core;
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

        public async Task<MessageTbl?> GetMessage(int messageId)
        {
            return await _context.MessageTbl
             .Include(c => c.MessageTopic)
             .Include(x => x.MessageText)
             .Include(x => x.ReciverMessageId)
             .Include(c => c.SubmitTime)

             .Where(c => c.MessageId == messageId).FirstOrDefaultAsync();
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
                Mtbl.Agent.SubCategoryId = message.Agent.SubCategoryId;
                Mtbl.Agent.Subset = message.Agent.Subset;
                Mtbl.ExpertSelectionId = message.ExpertSelectionId;
              

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
