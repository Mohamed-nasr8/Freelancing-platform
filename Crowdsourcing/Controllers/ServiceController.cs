using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.Helper;
using Crowdsourcing.DL.Entity;
using Crowdsourcing.BL.Interface;
using Microsoft.AspNetCore.Identity;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceController(IRepository<Service> repository,IMapper mapper , UserManager<ApplicationUser> userManager)
        {
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
                var model =  _mapper.Map<IEnumerable<ServiceVM>>(result);
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



        [HttpPost("ADDSERVICE")]

        public async Task<IActionResult> PostService( ServiceVM model)
        {
            
            try
            {

                if (ModelState.IsValid)
                {
                    var data =  _mapper.Map<Service>(model);

                    await _repository.AddAsync(data);

                    return Ok(new ApiResponse<Service>()
                    {
                        Code = "201",
                        Status = "Created",
                        Message = "Data Saved",
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


        //[HttpPut("EDITSERVICE")]
        //public async Task<IActionResult> PutService(ServiceVM model , int id)
        //{
        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var data = _mapper.Map<Service>(model);

        //            await _repository.UpdateAsync(id);

        //            return Ok(new ApiResponse<Service>()
        //            {
        //                Code = "200",
        //                Status = "Ok",
        //                Message = "Data Updated",
        //            });
        //        }

        //        return Ok(new ApiResponse<string>()
        //        {
        //            Code = "400",
        //            Status = "Not Valied",
        //            Message = "Data Invalid"
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(new ApiResponse<string>()
        //        {
        //            Code = "404",
        //            Status = "Faild",
        //            Message = "Not Created",
        //            Error = ex.Message
        //        });
        //    }
        //}


        [HttpDelete("DELETSERVICE")]

        public async Task<IActionResult> DeleteService(int id) 
        {
            try
            {
                

                await _repository.RemoveAsync(id);

                return Ok(new ApiResponse<ServiceVM>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Deleted",
                    
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

