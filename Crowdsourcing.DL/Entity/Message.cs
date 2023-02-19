using Crowdsourcing.DL.Entity;
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
        [DataType(DataType.DateTime)]
        public DateTime MessageTime { get;set; }
        [DataType(DataType.Text)]
        public string MessageText { get; set; }  
        
        public ICollection<Attachment> Attachment { get; set; }
        // Foreign Key From Class Proposal_status_Catalog
        public int? ProposalStatusCatalogId { get; set; }
        public ProposalStatusCatalog ProposalStatusCatalog { get; set; }
       
        // Foreign Key From Class Proposal
        public int ProposalId { get;set; }
        public Proposal Proposal { get; set; } 
        
        // Foreign Key From Class Hire Manager
        public int? ClientId { get; set; }
        public Client Client { get; set; }

        // Foreign Key From Class Freelancer
        public int? FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
