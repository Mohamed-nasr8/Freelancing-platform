using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        [Timestamp]
        public byte[] ProposalTime { get; set; }
        public decimal PaymentAmount { get; set; }
        public int DeleveryTime { get; set; }
        public string Descripion { get; set; }  
        public string Attachment { get; set; }  
        public ICollection<Message> Message { get; set; }

        // Foreign Key From Class Proposal_status_Id
        public int ProposalStatusCatalogId { get; set; }
        public ProposalStatusCatalog ProposalStatusCatalog { get; set; }
        
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
