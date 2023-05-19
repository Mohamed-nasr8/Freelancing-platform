using AutoMapper;
using Crowdsourcing.BL.Helper;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.Repository;
using Crowdsourcing.BL.ViewModels;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Crowdsourcing.DL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Crowdsourcing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IRepository<Proposal> _proposalRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;
        IRepository<Service> _repository;

        public ProposalController(IRepository<Proposal> proposalRepo, IMapper mapper,
            IHttpContextAccessor HttpAccessor, IRepository<Service> repository)
        {
            _proposalRepo = proposalRepo;
            _mapper = mapper;
            _httpAccessor = HttpAccessor;
            _repository = repository;
        }


        [HttpPost("AddProposal")]
        public async Task<IActionResult> Create([FromForm]ProposalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = await _repository.GetAsync(model.ServiceId);
                    // Map the ProposalRequest to a Proposal entity
                    var proposal = _mapper.Map<Proposal>(model);

                    // Set the FreelancerId to the current user's id
                    var userName = _httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                    // Check if the freelancer has already posted a proposal for this service
                    //var existingProposal = await _proposalRepo.GetAllAsync()
                    //    .Where(p => p.FreelancerId == userName && p.ServiceId == model.ServiceId)
                    //    .FirstOrDefaultAsync();

                    if (model.AttachmentFile != null)
                    {
                        proposal.Attachment = UploadFiles.UploadFile("/wwwroot/Files/AttachmentProposal", model.AttachmentFile);
                    }

                    // Add the Proposal entity to the repository and save changes
                    await _proposalRepo.AddAsync(proposal);
                    return Ok(new ApiResponse<Proposal>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Freelancer Added",
                        Data = proposal

                    });

                }

                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not Valied",
                    Message = "Data Invalid"
                });

            }

            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Added",
                    Error = ex.Message
                });
            }
        }
    }
}
