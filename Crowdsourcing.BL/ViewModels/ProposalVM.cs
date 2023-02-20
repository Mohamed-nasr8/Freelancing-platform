using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Models
{
    public class ProposalVM
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ProposalTime { get; set; }
        [DataType(DataType.Currency)]
        public decimal PaymentAmount { get; set; }
        [DataType(DataType.DateTime)]
        public int DeleveryTime { get; set; }
        [DataType(DataType.Text)]
        public string Descripion { get; set; }  
        public string Attachment { get; set; }  
        public ICollection<MessageVM> Message { get; set; }

        // Foreign Key From Class Proposal_status_Id
        public int ProposalStatusCatalogId { get; set; }
        public ProposalStatusCatalogVM ProposalStatusCatalog { get; set; }
        
        // Foreign Key From Class Job
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        // Foreign Key From Class Payment_type
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        // Foreign Key From Class Freelancer
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        public ICollection<Contract> Contracts { get; set; } 

    }
}
