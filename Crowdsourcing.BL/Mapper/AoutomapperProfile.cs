using AutoMapper;
using Crowdsourcing.BL.ViewModels;
using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Mapper
{
    public class AoutomapperProfile : Profile
    {

        public AoutomapperProfile()
        {
            CreateMap<Freelancer,FreelancerVM>();
            CreateMap<Education,EducationVM>();
            CreateMap<Expereince,ExpereinceVM>();
            CreateMap<Language,LanguageVM>();
            CreateMap<HasSkill,HasSkillVM>();
            CreateMap<HasFreelancerService,HasFreelancerServiceVM>();
            CreateMap<Withdraw,WithdrawVM>();


        }
    }
}
