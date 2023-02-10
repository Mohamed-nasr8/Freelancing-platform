﻿using System;
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
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }


        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int Payment_typeId { get; set; }

        public Payment_type Payment_type { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int VerificationId { get; set; }
        public Verification Verification { get; set; }

        public ICollection<other_skills> other_skills { get; set; }









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