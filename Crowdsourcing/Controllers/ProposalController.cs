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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IRepository<Proposal> _proposalRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;
        IRepository<Service> _repository;
        private readonly IRepository<Freelancer> _freelancerRepository;

        public ProposalController(IRepository<Proposal> proposalRepo, IMapper mapper,
            IHttpContextAccessor HttpAccessor, IRepository<Service> repository, IRepository<Freelancer> freelancerRepository)
        {
            _proposalRepo = proposalRepo;
            _mapper = mapper;
            _httpAccessor = HttpAccessor;
            _repository = repository;
            _freelancerRepository = freelancerRepository;
        }
        [HttpGet("Get_All")]
        public async Task<IActionResult> GetProposals()
        {
            try
            {
                var proposals = await _proposalRepo.GetAllAsyncEnum();
                //var mapper = _mapper.Map<IEnumerable<ProposalVM>>(proposals);

                return Ok(new ApiResponse<IEnumerable<Proposal>>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Proposal Get",
                    Data = proposals

                });
            }catch(Exception ex)
            {
                return NotFound( new ApiResponse<string>()
                { 
                    Code="404",
                    Status="Not Found",
                    Message="Proposal Not Found",
                    
                });

            }

        }
        [HttpGet("Get_By_Id")]
        public async Task<IActionResult> GetProposal(int id)
        {
            var proposal = await _proposalRepo.GetAsync(id);

            if (proposal == null)
            {
                return NotFound($"Proposal With ID ({id}) Not Found");
            }

            var mapper = _mapper.Map<ProposalVM>(proposal);

            return Ok(new ApiResponse<ProposalVM>
            {
                Code = "200",
                Status = "Ok",
                Message = $"Proposal With ID ({id}) Get",
                Data = mapper
            });
        }
        [HttpPost("AddProposal")]
        public async Task<IActionResult> Create([FromForm] ProposalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = await _repository.GetAsync(model.ServiceId);
                    var freelancer = await _freelancerRepository.GetAsync(model.FreelancerId);

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
                        Message = "Proposal Added",
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


        [HttpPut("UpadteProposal")]
        public async Task<IActionResult> Update([FromForm] ProposalUpdateVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {


                    //var service = await _repository.GetAsync(model.ServiceId);
                    //var freelancer = await _freelancerRepository.GetAsync(model.FreelancerId);


                    var data = _mapper.Map<Proposal>(model);

                    var userName = _httpAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);




                    if (model.AttachmentFile != null)
                    {
                        data.Attachment = UploadFiles.UpdateFile(data.Attachment, model.AttachmentFile, "/wwwroot/Files/Docs");
                    }
                    var updatedEntity = await _proposalRepo.UpdateAsync(data);





                    return Ok(new ApiResponse<Proposal>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Data Updated",
                        Data = data

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
                    Message = "Not Updated",
                    Error = ex.Message
                });
            }
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteProposal(int id)
        {
            try
            {
                await _proposalRepo.RemoveAsync(id);
                return Ok(new ApiResponse<Proposal>()
                {
                    Code = "200",
                    Status = "Deleted",
                    Message = "Proposal Deleted",

                });
            }catch(Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status =$" Proposal With ID ({id}) Not Found"
                });
            }

        }

    
    }
}
