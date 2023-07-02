using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Contract
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime),Required(ErrorMessage ="Requried Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime), Required(ErrorMessage = "Requried End Time")]

        public DateTime EndTime { get; set; }
        [DataType(DataType.Currency)]
        public decimal PaymentAmount { get;set; }
        // Foreign Key From Proposal
        public int ProposalId { get;set; }
        public Proposal Proposal { get;set;}

        // Foreign Key From Class Freelancer
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
