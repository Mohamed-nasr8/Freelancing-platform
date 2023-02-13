using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Models
{
    public class Contract
    {
        public int Id { get; set; }
        [Timestamp]
        public byte[] Start_Time { get; set; }
        [Timestamp]
        public byte[]? End_Time { get; set; }
        public decimal Payment_Amount { get;set; }
        // Foreign Key From Proposal
        public int ProposalId { get;set; }
        public Proposal Proposal { get;set;}

        // Foreign Key From Class Payment_Type
        public int Payment_typeId { get; set; }
        public Payment_type Payment_type { get; set; }

        // Foreign Key From Class Freelancer
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
