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
            CreateMap<FreelancerVM,Freelancer>();

            CreateMap<FreelancerSkill, FreelancerSkillVM>();
            CreateMap<FreelancerSkillVM, FreelancerSkill>();

            CreateMap<Freelancer, EditFreelancerVM>();
            CreateMap<EditFreelancerVM, Freelancer>();
            CreateMap<Education,EducationVM>();
            CreateMap<EducationVM,Education>();

            CreateMap<Expereince,ExpereinceVM>();
            CreateMap<ExpereinceVM,Expereince>();

            CreateMap<Language,LanguageVM>();
            CreateMap<LanguageVM,Language>();

            CreateMap<Withdraw,WithdrawVM>();
            CreateMap<WithdrawVM, Withdraw>();

            CreateMap<Message, MessageVM>();
            CreateMap<MessageVM, Message>();

            CreateMap<Contract, ContractVM>();
            CreateMap<ContractVM, Contract>();

            CreateMap<Attachment,AttachmentVM>();
            CreateMap<AttachmentVM,Attachment>();

            CreateMap<Proposal, ProposalVM>();
            CreateMap<ProposalVM, Proposal>();
            

            CreateMap<Proposal, ProposalUpdateVM>();
            CreateMap<ProposalUpdateVM, Proposal>();

            CreateMap<Notification, NotificationVM>();
            CreateMap<NotificationVM, Notification>();

            CreateMap<Rating, RatingVM>();
            CreateMap<RatingVM, Rating>();

            CreateMap<Client, ClientVM>();
            CreateMap<ClientVM, Client>();

            CreateMap<Service, ServiceVM>();
            CreateMap<ServiceVM, Service>();

            CreateMap<ServiceSkills, ServiceSkillsVM>();
            CreateMap<ServiceSkillsVM, ServiceSkills>();

            CreateMap<FreelancerService, FreelancerServiceVM>();
            CreateMap<FreelancerServiceVM, FreelancerService>();


            CreateMap<PaymentType, PaymentTypeVM>();
            CreateMap<PaymentTypeVM, PaymentType>();
            


        }
    }
}
