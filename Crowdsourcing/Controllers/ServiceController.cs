using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crowdsourcing.BL.Interface;
using TestAPIJWT.Service;
using AutoMapper;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.Helper;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.DL.Entity;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;

        public ServiceController(IRepository<Service> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GETALLSERVICE")]

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
                }             );


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

        public async Task<IActionResult> PostService(ServiceVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data =  _mapper.Map<Service>(model);

                 _repository.AddAsync(data);

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


        [HttpPut("EDITSERVICE")]
        public async Task<IActionResult> PUTtService(ServiceVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Service>(model);

                     _repository.UpdateAsync(data);

                    return Ok(new ApiResponse<Service>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Data Updated",
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


        [HttpDelete("DELETSERVICE")]

        public async Task<IActionResult> DeleteService(ServiceVM model) 
        {
            try
            {
                var data = _mapper.Map<Service>(model);

                _repository.RemoveAsync(data);

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

