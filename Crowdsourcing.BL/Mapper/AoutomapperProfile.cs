using AutoMapper;
using Crowdsourcing.BL.ViewModels;
using Crowdsourcing.DL.Entity;
using Crowdsourcing.DL.Models;


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
            CreateMap<Message, MessageVM>();
            CreateMap<Contract, ContractVM>();
            CreateMap<Attachment,AttachmentVM>();
            CreateMap<Proposal, ProposalVM>();
            CreateMap<ProposalStatusCatalog,ProposalStatusCatalogVM>();


        }
    }
}
