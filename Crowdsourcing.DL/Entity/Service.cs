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
        [Required]
        [EnumDataType(typeof(ServiceType))]

        public ServiceType Type { get; set; }
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
        [Required]

        [Range(1, int.MaxValue)]

        public int N_of_people { get; set; }
        [EnumDataType(typeof(ServiceStatus))]

        public ServiceStatus Status { get; set; }

        [Required]

        public DateTime Duration { get; set; }


        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int PaymentTypeId { get; set; }

        public PaymentType PaymentType { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public ICollection<OtherSkills> OtherSkills { get; set; }


        public enum ServiceType
        {
            Paid,
            Free
        }
        public enum ServiceStatus
        {
            Open,
            Resolved
        }

    }
}
