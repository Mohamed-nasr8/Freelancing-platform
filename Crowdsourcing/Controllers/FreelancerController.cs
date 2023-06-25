using AutoMapper;
using Crowdsourcing.BL.Helper;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.Repository;
using Crowdsourcing.BL.ViewModels;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace Crowdsourcing.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {

        private readonly IRepository<Freelancer> _freelancerRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Education> _eductionRepository;
        private readonly IRepository<Expereince> _experinceRepository;
        private readonly IRepository<FreelancerSkill> _skillRepository;
        private readonly IRepository<FreelancerService> _serviceRepository;
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IMapper _mapper;
        private readonly FreelancerRepository _freelancerRepo;
        private readonly CrowdsourcingContext _context;
        private readonly IHttpContextAccessor _httpAccessor;

        public FreelancerController(IRepository<Freelancer> freelancerRepository, IRepository<Language> languageRepository,
                                IRepository<Education> eductionRepository,
                                IRepository<Expereince> experinceRepository, IRepository<FreelancerSkill> skillRepository, 
                                IRepository<FreelancerService> ServiceRepository,
                                IRepository<Rating> ratingRepository, IMapper mapper, FreelancerRepository freelancerRepo,
                                CrowdsourcingContext context, IHttpContextAccessor HttpAccessor)
        {
            _freelancerRepository = freelancerRepository;
            _languageRepository = languageRepository;
            _eductionRepository = eductionRepository;
            _experinceRepository = experinceRepository;
            _skillRepository = skillRepository;
            _serviceRepository = ServiceRepository;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
            _freelancerRepo = freelancerRepo;
            _context = context;
            _httpAccessor = HttpAccessor;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var freelancers = await _freelancerRepository.GetAllAsyncEnum();
                return Ok(new ApiResponse<IEnumerable<Freelancer>>
                {
                    Code = "200",
                    Status = "Data Retrived",
                    Data = freelancers
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

            //try
            //{
            //    var freelancer = await _freelancerRepository.GetAllAsyncEnum();
            //    var languages = await _languageRepository.GetAllAsyncEnum();
            //    var educations = await _eductionRepository.GetAllAsyncEnum();
            //    var experinces = await _experinceRepository.GetAllAsyncEnum();
            //    var skills = await _skillRepository.GetAllAsyncEnum();
            //    var services = await _serviceRepository.GetAllAsyncEnum();
            //    var ratings = await _ratingRepository.GetAllAsyncEnum();

            //    return Ok(new ApiResponse<IEnumerable<Freelancer>>()
            //    {
            //        Code = "200",
            //        Status = "Ok",
            //        Message = "Data Retrieved",
            //        Data = freelancer.Select(freelancer => new Freelancer
            //        {
            //            Id = freelancer.Id,
            //            Overview = freelancer.Overview,
            //            CVName = freelancer.CVName,
            //            ImageName = freelancer.ImageName,
            //            Title = freelancer.Title,
            //            Bio = freelancer.Bio,
            //            Rating = freelancer.Rating,
            //            Country = freelancer.Country,
            //            City = freelancer.City,
            //            Street = freelancer.Street,
            //            PhoneNumber = freelancer.PhoneNumber,
            //            HourlyRate = freelancer.HourlyRate,
            //            UserId = freelancer.UserId,
            //            Point = freelancer.Point,
            //            Languages = languages.Where(lan => lan.FreelancerId == freelancer.Id).Select(lan => new Language
            //            {
            //                Id = lan.Id,
            //                LangName = lan.LangName,
            //                Level = lan.Level,
            //                FreelancerId = freelancer.Id
            //            }).ToList(),
            //            Educations = educations.Where(edu => edu.FreelancerId == freelancer.Id).Select(edu => new Education
            //            {
            //                Id = edu.Id,
            //                School = edu.School,
            //                Degree = edu.Degree,
            //                FeildOfStudy = edu.FeildOfStudy,
            //                DateFrom = edu.DateFrom,
            //                DateTo = edu.DateTo,
            //                Description = edu.Description,
            //                FreelancerId = edu.FreelancerId
            //            }).ToList(),
            //            Expereinces = experinces.Where(ex => ex.FreelancerId == freelancer.Id).Select(ex => new Expereince
            //            {
            //                Id = ex.Id,
            //                Title = ex.Title,
            //                Description = ex.Description,
            //                Region = ex.Region,
            //                Country = ex.Country,
            //                WorkingInThisRole = ex.WorkingInThisRole,
            //                Company= ex.Company,
            //                StartDate = ex.StartDate,
            //                EndDate = ex.EndDate,
            //                FreelancerId = ex.FreelancerId
            //            }).ToList(),
            //            FreelancerSkills = skills.Where(sk => sk.FreelancerId == freelancer.Id).Select(sk => new FreelancerSkill
            //            {
            //                Id = sk.Id,
            //                Name = sk.Name,
            //                FreelancerId = sk.FreelancerId
            //            }).ToList(),
            //            FreelancerServices = services.Where(se => se.FreelancerId == freelancer.Id).Select(se => new FreelancerService
            //            {
            //                Id = se.Id,
            //                Category = se.Category,
            //                SubCategory= se.SubCategory,
            //                FreelancerId = se.FreelancerId
            //            }).ToList(),
            //            Ratings = ratings.Where(ra => ra.FreelancerId == freelancer.Id).Select(ra => new Rating
            //            {
            //                Id = ra.Id,
            //                RatingValue = ra.RatingValue,
            //                Comment = ra.Comment,
            //                FreelancerId = ra.FreelancerId,
            //                ClientId = ra.ClientId
            //            }).ToList(),
            //        }).ToList()
            //    });
            //}
            //catch (Exception ex)
            //{
            //    return NotFound(new ApiResponse<String>()
            //    {
            //        Code = "404",
            //        Status = "Not Found",
            //        Message = "Data Not Found",
            //        Error = ex.Message
            //    });
            //}


        }

        [HttpGet("GetAllById")]
        public async Task<IActionResult> GetAllById(int id)
        {
            try
            {

                var freelancer = await _freelancerRepository.GetAsync(id);
                if (freelancer == null)
                {
                    return NotFound(new ApiResponse<String>()
                    {
                        Code = "404",
                        Status = "Not Found",
                        Message = "Data Not Found",
                        Error = $"Freelancer with ID {id} not found"
                    });
                }
                var languages = await _languageRepository.GetAllAsyncEnum(id);
                var educations = await _freelancerRepo.GetAllAsyncEducation(id);
                var experinces = await _experinceRepository.GetAllAsyncEnum(id);
                var skills = await _skillRepository.GetAllAsyncEnum(id);
                var services = await _serviceRepository.GetAllAsyncEnum(id);
                var ratings = await _ratingRepository.GetAllAsyncEnum(id);
                return Ok(new ApiResponse<Freelancer>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Retrieved",
                    Data = new Freelancer
                    {
                        Id = freelancer.Id,
                        Overview = freelancer.Overview,
                        CVName = freelancer.CVName,
                        ImageName = freelancer.ImageName,
                        Title = freelancer.Title,
                        Bio = freelancer.Bio,
                        Rating = freelancer.Rating,
                        Country = freelancer.Country,
                        City = freelancer.City,
                        Street = freelancer.Street,
                        HourlyRate = freelancer.HourlyRate,
                        PhoneNumber = freelancer.PhoneNumber,
                        Point = freelancer.Point,
                        Languages = languages.Select(lan => new Language
                        {
                            Id = lan.Id,
                            LangName = lan.LangName,
                            Level = lan.Level,
                            FreelancerId = freelancer.Id
                        }).ToList(),
                        Educations = educations.Select(edu => new Education
                        {
                            Id = edu.Id,
                            School = edu.School,
                            Degree = edu.Degree,
                            FeildOfStudy = edu.FeildOfStudy,
                            DateFrom = edu.DateFrom,
                            DateTo = edu.DateTo,
                            Description = edu.Description,
                            FreelancerId = edu.FreelancerId
                        }).ToList(),

                        Expereinces = experinces.Select(ex => new Expereince
                        {
                            Id = ex.Id,
                            Title = ex.Title,
                            Description = ex.Description,
                            Region = ex.Region,
                            Country = ex.Country,
                            Company = ex.Company,
                            WorkingInThisRole = ex.WorkingInThisRole,
                            StartDate = ex.StartDate,
                            EndDate = ex.EndDate,
                            FreelancerId = ex.FreelancerId
                        }).ToList(),
                        Ratings = ratings.Select(ra => new Rating
                        {
                            Id = ra.Id,
                            RatingValue = ra.RatingValue,
                            Comment = ra.Comment,
                            FreelancerId = ra.FreelancerId,
                            ClientId = ra.ClientId
                        }).ToList(),
                        FreelancerSkills = skills.Select(sk => new FreelancerSkill
                        {
                            Id = sk.Id,
                            Name = sk.Name,
                            FreelancerId = sk.FreelancerId
                        }).ToList(),
                        FreelancerServices = services.Select(se => new FreelancerService
                        {
                            Id = se.Id,
                            Category = se.Category,
                            SubCategory= se.SubCategory,
                            FreelancerId = se.FreelancerId
                        }).ToList(),
                    }

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
                });
            }

        }


        [HttpGet("GetCurrentFreelancer")]
        public IActionResult GetRelatedData()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var CurrentUser = _context.Users.FirstOrDefault(u => u.UserName == username);


            if (CurrentUser.RoleName != "Freelancer")
            {
                return BadRequest("You are't Freelancer");
            }
            if (CurrentUser.Id == null)
            {
                return BadRequest("User claims not found.");
            }

            // Retrieve related data for Freelancer
            var freelancer = _context.Freelancers
            .Include(f => f.User)
               .Include(ex => ex.Expereinces)
                        .Include(l => l.Languages)
                        .Include(ed => ed.Educations)
                        .Include(sk => sk.FreelancerSkills)
                        .Include(se => se.FreelancerServices)
                        .Include(w => w.Withdraws)
                        .Include(p => p.Proposals)
                        .Include(r => r.Ratings)
                .SingleOrDefault(f => f.UserId == CurrentUser.Id);


            return Ok(new
            {
                Freelancer = freelancer
            });
        }


        [HttpPost("AddFreelancer")]
        public async Task<IActionResult> Create([FromForm] FreelancerVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Freelancer>(model);

                    var username = _httpAccessor.HttpContext.User?
                        .FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    var CurrentUser = _context.Users.FirstOrDefault(u => u.UserName == username);


                    // Set the UserId property of the Freelancer object to the current user's ID
                    data.UserId = CurrentUser.Id;

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
                    var skills = _mapper.Map<List<FreelancerSkill>>(model.Skills);
                    var services = _mapper.Map<List<FreelancerService>>(model.Services);


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
                    foreach (var skill in skills)
                    {
                        skill.FreelancerId=model.Skills.First().FreelancerId;
                    }
                    foreach (var service in services)
                    {
                        service.FreelancerId = model.Services.First().FreelancerId;
                    }

                    // Add the entities to the context and save changes
                    await _context.AddRangeAsync(languages);
                    await _context.AddRangeAsync(experiences);
                    await _context.AddRangeAsync(educations);
                    await _context.AddRangeAsync(skills);
                    await _context.AddRangeAsync(services);

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

        [HttpPut("Edit")]
        public async Task<IActionResult> Update([FromForm] EditFreelancerVM model)
        {

            try
            {

                if (ModelState.IsValid)
                {


                    var username = _httpAccessor.HttpContext.User?
                        .FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                    var CurrentUser = _context.Users.FirstOrDefault(u => u.UserName == username);

                    var data = _mapper.Map<Freelancer>(model);



                    // Set the UserId property of the Freelancer object to the current user's ID
                    data.UserId = CurrentUser.Id;

                    if (model.Photo != null)
                    {
                        data.ImageName = UploadFiles.UpdateFile(data.ImageName, model.Photo, "/wwwroot/Files/Imgs");
                    }

                    if (model.Cv != null)
                    {
                        data.CVName = UploadFiles.UpdateFile(data.CVName, model.Cv, "/wwwroot/Files/Docs");
                    }
                    var updatedEntity = await _freelancerRepository.UpdateAsync(data);

                    // Retrieve related data for Freelancer
                    var freelancer = _context.Freelancers
                        .Include(f => f.User).Include(ex => ex.Expereinces)
                        .Include(l => l.Languages)
                        .Include(ed => ed.Educations)
                        .Include(sk => sk.FreelancerSkills)
                        .Include(se => se.FreelancerServices)
                        .Include(w => w.Withdraws)
                        .Include(p => p.Proposals)
                        .Include(r => r.Ratings)
                        .FirstOrDefault(f => f.UserId == CurrentUser.Id);



                    return Ok(new ApiResponse<Freelancer>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Data Updated",
                        Data = freelancer

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

        [HttpPut("EditLanExED/{id}")]
        public async Task<IActionResult> Update(int id, CreateFreelancerRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Map the language, experience, and education lists from the request to entities
                    var languages = _mapper.Map<List<Language>>(model.Languages);
                    var experiences = _mapper.Map<List<Expereince>>(model.Experiences);
                    var educations = _mapper.Map<List<Education>>(model.Educations);
                    var skills = _mapper.Map<List<FreelancerSkill>>(model.Skills);
                    var services = _mapper.Map<List<FreelancerService>>(model.Services);
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
                    foreach (var skill in skills)
                    {
                        skill.FreelancerId = model.Skills.First().FreelancerId;
                    }
                    foreach (var service in services)
                    {
                        service.FreelancerId = model.Services.First().FreelancerId;
                    }

                    // Remove the existing entities with the same freelancerId
                    _context.Languages.RemoveRange(_context.Languages.Where(x => x.FreelancerId == id));
                    _context.Expereinces.RemoveRange(_context.Expereinces.Where(x => x.FreelancerId == id));
                    _context.Educations.RemoveRange(_context.Educations.Where(x => x.FreelancerId == id));
                    _context.FreelancerSkills.RemoveRange(_context.FreelancerSkills.Where(x => x.FreelancerId == id));
                    _context.FreelancerServices.RemoveRange(_context.FreelancerServices.Where(x => x.FreelancerId == id));


                    // Add the new entities to the context and save changes
                    await _context.AddRangeAsync(languages);
                    await _context.AddRangeAsync(experiences);
                    await _context.AddRangeAsync(educations);
                    await _context.AddRangeAsync(skills);
                    await _context.AddRangeAsync(services);
                    await _context.SaveChangesAsync();

                    // Return a success response with the added entities
                    return Ok(new ApiResponse<CreateFreelancerRequest>()
                    {
                        Code = "200",
                        Status = "Ok",
                        Message = "Freelancer Updated",
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

                var username = _httpAccessor.HttpContext.User?
                        .FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                var CurrentUser = _context.Users.FirstOrDefault(u => u.UserName == username);

                if (CurrentUser != null)
                {
                    _context.Remove(CurrentUser);
                    _context.SaveChanges();
                }

                //await _freelancerRepository.RemoveAsync(id);

                return Ok(new ApiResponse<Freelancer>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Data Deleted",
                    Data = freelancer
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>()
                {
                    Code = "500",
                    Status = "Error",
                    Message = "An error occurred while deleting the entity",
                    Error = ex.Message
                });
            }
        }
    }
}
