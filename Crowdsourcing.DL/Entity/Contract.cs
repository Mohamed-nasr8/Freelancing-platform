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

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public decimal PaymentAmount { get;set; }
        // Foreign Key From Proposal
        public int ProposalId { get;set; }
        public Proposal Proposal { get;set;}

        // Foreign Key From Class Payment_Type
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        // Foreign Key From Class Freelancer
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
