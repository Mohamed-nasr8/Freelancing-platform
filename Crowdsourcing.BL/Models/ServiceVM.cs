using Crowdsourcing.DL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Crowdsourcing.DL.Entity.Service;

namespace Crowdsourcing.BL.Models
{
    public class ServiceVM
    {

        public int Id { get; set; }

        //public ServiceType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Payment_amount { get; set; }
        public string Location { get; set; }
        public ServiceStatus Status { get; set; }
        public DateTime Postedtime { get; set; }
        [Required]
        public ExperienceLevel Level { get; set; }

        [Required]
        public int RequiredTimeInDays { get; set; }

        public int ClientId { get; set; }
        public int PaymentTypeId { get; set; }
        //public int SkillId { get; set; }

        //public enum ServiceType
        //{
        //    Paid,
        //    Free
        //}
        public enum ServiceStatus
        {
            Open,
            Resolved
        }

        public enum ExperienceLevel
        {
            Beginner,
            Intermediate,
            Professional
        }


    }
}
