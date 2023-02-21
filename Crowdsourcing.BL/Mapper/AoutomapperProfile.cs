using AutoMapper;
using Crowdsourcing.BL.Models;
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
            CreateMap<UserAccount, UserAccounVM>();
            CreateMap<UserAccounVM, UserAccount>();
            CreateMap<Notification, NotificationVM>();
            CreateMap<NotificationVM, Notification>();
            CreateMap<Rating, RatingVM>();
            CreateMap<RatingVM, Rating>();
            CreateMap<Client, ClientVM>();
            CreateMap<ClientVM, Client>();
            CreateMap<Service, ServiceVM>();
            CreateMap<ServiceVM, Service>();
            CreateMap<OtherSkills, OtherSkillsVM>();
            CreateMap<OtherSkillsVM, OtherSkills>();
            CreateMap<Verification, VerificationVM>();
            CreateMap<VerificationVM, Verification>();
            CreateMap<FreelancerService, FreelancerServiceVM>();
            CreateMap<FreelancerServiceVM, FreelancerService>();
            CreateMap<Skill, SkillVM>();
            CreateMap<SkillVM, Skill>();
            CreateMap<PaymentType, PaymentTypeVM>();
            CreateMap<PaymentTypeVM, PaymentType>();
            





















        }
    }
}
