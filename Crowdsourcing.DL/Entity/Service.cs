using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Service
    {
        public int Id { get; set; }
        //[Required]
        //[EnumDataType(typeof(ServiceType))]

        //public ServiceType Type { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        [DataType(DataType.Currency)]

        [Required]

        public decimal Payment_amount { get; set; }

        public string Location { get; set; }


        [EnumDataType(typeof(ServiceStatus))]

        public ServiceStatus Status { get; set; }

        [Required]

        public DateTime Postedtime { get; set; }


        [Required]
        public ExperienceLevel Level { get; set; }

        [Required]
        public int RequiredTimeInDays { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }


        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        //public int SkillId { get; set; }

        //public Skill Skill { get; set; }

        public ICollection<ServiceSkills> ServiceSkills { get; set; }


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
