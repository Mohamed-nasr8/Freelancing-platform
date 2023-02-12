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
        public byte[] Proposal_Time { get; set; }
        public decimal Payment_Amount { get; set; }
        public int Delevery_Time { get; set; }
        public string Descripion { get; set; }  
        public string Attachment { get; set; }  
        public ICollection<Message> Message { get; set; }

        // Foreign Key From Class Proposal_status_Id
        public int ProposalStatusCatalogId { get; set; }
        public Proposal_Status_Catalog ProposalStatusCatalog { get; set; }
        
        // Foreign Key From Class Job
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        // Foreign Key From Class Payment_type
        public int Payment_typeId { get; set; }
        public Payment_type Payment_type { get; set; }

        // Foreign Key From Class Freelancer
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public ICollection<Contract> Contract { get; set; } 

    }
}
