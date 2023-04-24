using AutoMapper;
using Crowdsourcing.BL.Helper;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.ViewModels;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IRepository<Freelancer> _freelancerRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        
        public FreelancerController(IRepository<Freelancer> freelancerRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _freelancerRepository = freelancerRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var freelancer = await _freelancerRepository.GetAllAsync();
                var model = _mapper.Map<IEnumerable<FreelancerVM>>(freelancer);
                return Ok(new ApiResponse<IEnumerable<FreelancerVM>>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrived",
                    Data = model
                });
            }
            catch(Exception ex)
            {
                return NotFound(new ApiResponse<String>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message

                });

            }
        }
        [HttpGet("GetAllById")]
        public async Task<IActionResult> GetAllById(int id)
        {
            try
            {
                var freelancer = await _freelancerRepository.GetAsync(id);
                var model = _mapper.Map<IEnumerable<FreelancerVM>>(freelancer);
                return Ok(new ApiResponse<IEnumerable<FreelancerVM>>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrived",
                    Data = model
                });
            }catch(Exception ex)
            {
                return NotFound(new ApiResponse<String>()
                {
                    Code = "404",
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Error = ex.Message

                });
            }
            }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {


              await _freelancerRepository.RemoveAsync(id);

                return Ok(new ApiResponse<FreelancerVM>()
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

        [HttpPut("Edit")]
        public async Task<IActionResult> PutService([FromForm] FreelancerVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    

                    var data = _mapper.Map<Freelancer>(model);
                    ////if (model.Photo != null)
                    ////{
                    ////    data.ImageName = await UploadFiles.UpdateFileAsync("Imgs", data.ImageName, model.Photo);
                    ////}
                    //data.ImageName = UploadFiles.UploadFile("/wwwroot/Files/Imgs", model.Photo);
                    //data.CVName = UploadFiles.UploadFile("/wwwroot/Files/Docs", model.Cv);

                    ////if (model.Cv != null)
                    ////{
                    ////    data.CVName = await UploadFiles.UpdateFileAsync("Docs", data.CVName, model.Cv);
                    ////}
                    if (model.Photo != null)
                    {
                        data.ImageName = UploadFiles.UpdateFile(data.ImageName, model.Photo, "/wwwroot/Files/Imgs");
                    }

                    if (model.Cv != null)
                    {
                        data.CVName = UploadFiles.UpdateFile(data.CVName, model.Cv, "/wwwroot/Files/Docs");
                    }
                    var updatedEntity = await _freelancerRepository.UpdateAsync(data);


                    return Ok(new ApiResponse<Freelancer>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Data Updated",
                                        Data = updatedEntity

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



    }
}
