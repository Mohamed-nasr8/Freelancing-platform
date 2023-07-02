using Crowdsourcing.BL.Helper;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.SignalR;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IRepository<Freelancer> _freelancerRepository;
        private readonly CrowdsourcingContext _context;

        public ChatController(IMessageRepository messageRepository, IHubContext<ChatHub> hubContext, IRepository<Freelancer> freelancerRepository, CrowdsourcingContext context)
        {
            _messageRepository = messageRepository;
            _hubContext = hubContext;
            _freelancerRepository = freelancerRepository;
            _context = context;
        }

        [HttpPost("client")]
        public async Task<IActionResult> SendClientMessage(int clientId, int freelancerId, string messageContent)


        {
            try
            {

                //var freelancer = await _freelancerRepository.GetAsync(freelancerId);
                //var Client = await _context.Clients.FindAsync(clientId);

                var message = new Message
                {
                    ClientId = clientId,
                    FreelancerId = freelancerId,
                    Content = messageContent,
                    SentAt = DateTime.Now
                };

                await _messageRepository.CreateMessage(message);

               await _hubContext.Clients.Users(clientId.ToString(), freelancerId.ToString()).SendAsync("ReceiveMessage", message);


                return Ok(new ApiResponse<Message>()
                {
                    Code = "200",
                    Status = "Ok",
                  Message = "Sended",
                    Data = message

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Sended",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("freelancer")]
        public async Task<IActionResult> SendFreelancerMessage(int clientId, int freelancerId, string messageContent)
        {
            try
            {
                var message = new Message
                {
                    ClientId = clientId,
                    FreelancerId = freelancerId,
                    Content = messageContent,
                    SentAt = DateTime.Now
                };
                
                await _messageRepository.CreateMessage(message);

                await _hubContext.Clients.Users(freelancerId.ToString(), clientId.ToString()).SendAsync("ReceiveMessage", message);
                return Ok(new ApiResponse<Message>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Sended",
                    Data = message

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Sended",
                    Error = ex.Message
                });



            }
        
        }

    }
}