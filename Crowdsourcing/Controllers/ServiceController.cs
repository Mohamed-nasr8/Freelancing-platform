using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.Helper;
using Crowdsourcing.DL.Entity;
using Crowdsourcing.BL.Interface;
using Microsoft.AspNetCore.Identity;
using Crowdsourcing.BL.Repository;
using Crowdsourcing.DL.Database;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Crowdsourcing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly CrowdsourcingContext _context;
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceController(CrowdsourcingContext context , IRepository<Service> repository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("getAllServices")]

        public async Task<IActionResult> GetSERVICEAsync()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                var model = _mapper.Map<IEnumerable<ServiceVM>>(result);
                return Ok(new ApiResponse<IEnumerable<ServiceVM>>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrived",
                    Data = model
                }
                );


            }

            catch (Exception ex)
            {
                return NotFound(new ApiResponse<String>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message

                }


                    );
            }



        }

        [HttpGet("GETSERVICEBYID")]
        public async Task<IActionResult> GetSERVICEAsyncById(int id)
        {
            try
            {
                var result = await _repository.GetAsync(id);
                var model = _mapper.Map<ServiceVM>(result);
                return Ok(new ApiResponse<ServiceVM>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrived",
                    Data = model
                });


            }

            catch (Exception ex)
            {
                return NotFound(new ApiResponse<String>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message

                }


                    );
            }



        }



        [HttpGet("GetCurrentClient")]
        public IActionResult GetRelatedData()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var CurrentUser = _context.Users.FirstOrDefault(u => u.UserName == username);
            if(CurrentUser.RoleName != "Client")
            {
                return BadRequest("You are't Client");
            }
            if (CurrentUser.Id == null)
            {
                return BadRequest("User claims not found.");
            }


            // Retrieve related data for Client
            var client = _context.Clients
                .Include(c => c.User)
                .Include(s => s.Services)
                .SingleOrDefault(c => c.UserId == CurrentUser.Id);

            return Ok(new
            {
                Client = client
            });
        }




        [HttpPost("ADDSERVICE")]

        public async Task<IActionResult> PostService(ServiceVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Service>(model);

                    await _repository.AddAsync(data);

                    return Ok(new ApiResponse<Service>()
                    {
                        Code = "201",
                        Status = "Created",
                        Message = "Data Saved",
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
                    Message = "Not Created",
                    Error = ex.Message
                });
            }


        }


        [HttpPut("EDITSERVICE")]
        public async Task<IActionResult> PutService([FromBody] ServiceVM serviceVM)
        {
            try
            {
                var data = _mapper.Map<Service>(serviceVM);

            
             var existingEntity =   await _repository.UpdateAsync(data);

                return Ok(new ApiResponse<Service>()
                {
                    Code = "200",
                    Status = "Data Updated",
                    Message = "Data Updated",
                    Data = existingEntity
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


        [HttpDelete("DELETSERVICE")]

        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                var services = await _repository.GetAsync(id);
                var model = _mapper.Map<ServiceVM>(services);
                await _repository.RemoveAsync(id);

                return Ok(new ApiResponse<ServiceVM>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Deleted",
                    Data = model

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Created",
                    Error = ex.Message
                });
            }
        }


    }
}

