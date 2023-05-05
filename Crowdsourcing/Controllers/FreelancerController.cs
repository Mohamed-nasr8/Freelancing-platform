using AutoMapper;
using Crowdsourcing.BL.Helper;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.Repository;
using Crowdsourcing.BL.ViewModels;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly CrowdsourcingContext _context;
        private readonly IRepository<Freelancer> _freelancerRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        
        public FreelancerController(CrowdsourcingContext context , IRepository<Freelancer> freelancerRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
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





        [HttpPost("AddFreelancer")]
        public async Task<IActionResult> Create([FromForm] FreelancerVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Freelancer>(model);


                    if (model.Photo != null)
                    {
                        data.ImageName = UploadFiles.UploadFile("/wwwroot/Files/Imgs", model.Photo);
                    }

                    if (model.Cv != null)
                    {
                        data.CVName = UploadFiles.UploadFile("/wwwroot/Files/Docs", model.Cv);
                    }
                    await _freelancerRepository.AddAsync(data);


                    return Ok(new ApiResponse<Freelancer>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Freelancer Added",
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
                    Message = "Not Added",
                    Error = ex.Message
                });
            }
        }


        [HttpPost("AddLanExED")]
        public async Task<IActionResult> Create(CreateFreelancerRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Map the language, experience, and education lists from the request to entities
                    var languages = _mapper.Map<List<Language>>(model.Languages);
                    var experiences = _mapper.Map<List<Expereince>>(model.Experiences);
                    var educations = _mapper.Map<List<Education>>(model.Educations);

                    // Set the foreign key properties of each entity to the passed in freelancerId parameter
                    foreach (var language in languages)
                    {
                        language.FreelancerId = model.Languages.First().FreelancerId;
                    }

                    foreach (var experience in experiences)
                    {
                        experience.FreelancerId = model.Experiences.First().FreelancerId;
                    }
                    foreach (var education in educations)
                    {
                        education.FreelancerId = model.Educations.First().FreelancerId;
                    }

                    // Add the entities to the context and save changes
                    await _context.AddRangeAsync(languages);
                    await _context.AddRangeAsync(experiences);
                    await _context.AddRangeAsync(educations);
                    await _context.SaveChangesAsync();

                    // Return a success response with the added entities
                    return Ok(new ApiResponse<CreateFreelancerRequest>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Freelancer Added",
                        Data = model
                    });
                }

                // Return a validation error response if the model state is not valid
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not Valid",
                    Message = "Data Invalid"
                });
            }
            catch (Exception ex)
            {
                // Return an error response if an exception occurs
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Failed",
                    Message = "Not Added",
                    Error = ex.Message
                });
            }
        }


        #region Add Freelancer , Education , Experience and Language
        //[HttpPost("AddFreelancer")]
        //public async Task<IActionResult> Create([FromForm] CreateFreelancerRequest model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // Map the data from the request to the Freelancer entity using AutoMapper
        //            var freelancer = _mapper.Map<Freelancer>(model.Freelancer);

        //            // Map the education data to the Freelancer's Educations collection using AutoMapper
        //            if (model.Educations != null && model.Educations.Any())
        //            {
        //                var educations = _mapper.Map<List<Education>>(model.Educations);
        //                freelancer.Educations = educations;
        //            }

        //            // Map the experience data to the Freelancer's Experiences collection using AutoMapper
        //            if (model.Experiences != null && model.Experiences.Any())
        //            {
        //                var experiences = _mapper.Map<List<Expereince>>(model.Experiences);
        //                freelancer.Expereinces = experiences;
        //            }

        //            // Map the language data to the Freelancer's Languages collection using AutoMapper
        //            if (model.Languages != null && model.Languages.Any())
        //            {
        //                var languages = _mapper.Map<List<Language>>(model.Languages);
        //                freelancer.Languages = languages;
        //            }
        //            if (model.Freelancer.Photo != null)
        //            {
        //                model.Freelancer.PhotoName = UploadFiles.UploadFile("/wwwroot/Files/Imgs", model.Freelancer.Photo);
        //            }

        //            if (model.Freelancer.Cv != null)
        //            {
        //                model.Freelancer.CvName = UploadFiles.UploadFile("/wwwroot/Files/Docs", model.Freelancer.Cv);
        //            }
        //            // Add the Freelancer entity to the database and save changes
        //            await _freelancerRepository.AddAsync(freelancer);


        //            return Ok(new ApiResponse<Freelancer>()
        //            {
        //                Code = "200",
        //                Status = "Ok",
        //                Message = "Freelancer Added",
        //                Data = freelancer

        //            });
        //        }


        //        return Ok(new ApiResponse<string>()
        //        {
        //            Code = "400",
        //            Status = "Not Valied",
        //            Message = "Data Invalid"
        //        });

        //    }

        //    catch (DbUpdateException ex)
        //    {
        //        return NotFound(new ApiResponse<string>()
        //        {
        //            Code = "404",
        //            Status = "Faild",
        //            Message = "Not Added",
        //            Error = ex.Message
        //        });
        //    }
        //}
        #endregion



        [HttpPut("Edit")]
        public async Task<IActionResult> Update([FromForm] FreelancerVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {



                    var data = _mapper.Map<Freelancer>(model);

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



        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var freelancer = await _freelancerRepository.GetAsync(id);
                var model = _mapper.Map<FreelancerVM>(freelancer);
                var dataModel = _mapper.Map<Freelancer>(model);
                UploadFiles.RemoveFile("Imgs", dataModel.ImageName);
                UploadFiles.RemoveFile("Docs", dataModel.CVName);
                await _freelancerRepository.RemoveAsync(id);



                return Ok(new ApiResponse<Freelancer>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Deleted",
                    Data = dataModel
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Deleted",
                    Error = ex.Message
                });
            }

        }
    








        

    }
}
