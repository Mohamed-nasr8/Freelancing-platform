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
    public class MessageRepository : IMessageRepository
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


        public async Task<IEnumerable<Message>> GetMessagesByClientId(int clientId)
        {
            return await _dbContext.Messages
                .Include(m => m.Freelancer)
                .ThenInclude(f => f.User) // Include the User navigation property in Freelancer
                .Include(m => m.Client)
                .ThenInclude(c => c.User) // Include the User navigation property in Client
                .Where(m => m.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByFreelancerId(int freelancerId)
        {
            return await _dbContext.Messages
                .Include(m => m.Freelancer)
                .ThenInclude(f => f.User) // Include the User navigation property in Freelancer
                .Include(m => m.Client)
                .ThenInclude(c => c.User) // Include the User navigation property in Client
                .Where(m => m.FreelancerId == freelancerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByParticipants(int clientId, int freelancerId)
        {
            return await _dbContext.Messages
                .Include(m => m.Freelancer)
                .ThenInclude(f => f.User) // Include the User navigation property in Freelancer
                .Include(m => m.Client)
                .ThenInclude(c => c.User) // Include the User navigation property in Client
                .Where(m => (m.ClientId == clientId && m.FreelancerId == freelancerId) ||
                            (m.ClientId == freelancerId && m.FreelancerId == clientId))
                .ToListAsync();
        }

        public async Task<Message> GetMessageById(int messageId)
        {
            return await _dbContext.Messages
                .Include(m => m.Freelancer)
                .ThenInclude(f => f.User) // Include the User navigation property in Freelancer
                .Include(m => m.Client)
                .ThenInclude(c => c.User) // Include the User navigation property in Client
                .FirstOrDefaultAsync(m => m.Id == messageId);
        }

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            return await _dbContext.Messages
                .Include(m => m.Freelancer)
                .ThenInclude(f => f.User) // Include the User navigation property in Freelancer
                .Include(m => m.Client)
                .ThenInclude(c => c.User) // Include the User navigation property in Client
                .ToListAsync();
        }
    }
}


