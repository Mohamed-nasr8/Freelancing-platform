using Crowdsourcing.BL.Interface;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMessageRepository _messageRepository;

        public ChatHub(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task SendClientMessage(int clientId, int freelancerId, string messageContent)
        {
            var message = new Message
            {
                ClientId = clientId,
                FreelancerId = freelancerId,
                Content = messageContent,
                SentAt = DateTime.Now
            };

            await _messageRepository.CreateMessage(message);

            await Clients.Users(clientId.ToString(), freelancerId.ToString()).SendAsync("ReceiveMessage", message);
        }

        public async Task SendFreelancerMessage(int clientId, int freelancerId, string messageContent)
        {
            var message = new Message
            {
                ClientId = clientId,
                FreelancerId = freelancerId,
                Content = messageContent,
                SentAt = DateTime.Now
            };

            await _messageRepository.CreateMessage(message);

            await Clients.Users(freelancerId.ToString(), clientId.ToString()).SendAsync("ReceiveMessage", message);
        }
    }
}
