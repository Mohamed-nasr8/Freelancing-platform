﻿using Crowdsourcing.DL.Entity;
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
        [Required(ErrorMessage = "Service type is required.")]
        [EnumDataType(typeof(ServiceType), ErrorMessage = "Invalid service type.")]
        public ServiceType Type { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Payment amount is required.")]
        [Column(TypeName = "decimal(8,2)")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid payment amount.")]
        public decimal Payment_amount { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "Number of people is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid number of people.")]
        public int N_of_people { get; set; }

        [EnumDataType(typeof(ServiceStatus), ErrorMessage = "Invalid service status.")]
        public ServiceStatus Status { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [DataType(DataType.Duration, ErrorMessage = "Invalid duration.")]
        public TimeSpan Duration { get; set; }

       
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int Payment_typeId { get; set; }

        public PaymentType PaymentType { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int VerificationId { get; set; }

        public Verification Verification { get; set; }

        public ICollection<OtherSkills> OtherSkills { get; set; }


    }
}