using Crowdsourcing.BL.Interface;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Repository
{
    public class MessageRepository:IMessageRepository
    {
        private readonly CrowdsourcingContext _dbContext;

        public MessageRepository(CrowdsourcingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Message> CreateMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            await _dbContext.SaveChangesAsync();
            return message;
        }

        public async Task<IEnumerable<Message>> GetMessages(int FreelancerId, int ClintId)
        {
            return await _dbContext.Messages
                .Where(m => (m.FreelancerId == FreelancerId && m.ClientId == ClintId) ||
                            (m.ClientId == ClintId && m.FreelancerId == FreelancerId))
                .ToListAsync();
        }
    }
}

