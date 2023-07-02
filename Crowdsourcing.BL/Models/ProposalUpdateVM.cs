using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class ProposalUpdateVM
    {

        public int Id { get; set; }
        //[DataType(DataType.DateTime), Required(ErrorMessage = "Requried Proposal Time")]
        //public DateTime ProposalTime { get; set; }
        [DataType(DataType.Currency), Required(ErrorMessage = "Requried Payment Amount")]
        public decimal PaymentAmount { get; set; }
        [Required(ErrorMessage = "Requried Delevery Time")]
        public int DeleveryTime { get; set; }
        [DataType(DataType.Text), Required(ErrorMessage = "Requried Description")]
        public string Descripion { get; set; }
        public string? Attachment { get; set; }
        public IFormFile? AttachmentFile { get; set; }

        public ProposalStatus Status { get; set; }


        // Foreign Key From Class Job
        public int ServiceId { get; set; }

       

        // Foreign Key From Class Freelancer
        public int FreelancerId { get; set; }

    }
}
