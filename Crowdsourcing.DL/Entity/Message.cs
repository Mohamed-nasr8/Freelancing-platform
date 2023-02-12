using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Timestamp]
        public byte[] Message_Time { get;set; }
        public string Message_Text { get; set; }  
        
        public ICollection<Attachment> Attachment { get; set; }
        // Foreign Key From Class Proposal_status_Catalog
        public int? ProposalStatusCatalogId { get; set; }
        public Proposal_Status_Catalog ProposalStatusCatalog { get; set; }
       
        // Foreign Key From Class Proposal
        public int ProposalId { get;set; }
        public Proposal Proposal { get; set; } 
        
        // Foreign Key From Class Hire Manager
        public int? HireManagerId { get; set; }
        public Hire_ManagerId Hire_Manager { get; set; }

        // Foreign Key From Class Freelancer
        public int? FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
