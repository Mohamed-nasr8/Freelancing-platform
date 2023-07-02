using Crowdsourcing.DL.Entity;
using Crowdsourcing.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Interface
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessage(Message message);
        Task<IEnumerable<Message>> GetMessages(int FreelancerId, int ClintId);
    }
}
