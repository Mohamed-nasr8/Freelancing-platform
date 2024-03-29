﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Expereince
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }


        [Required]
        [MaxLength(200)]
        public string Company { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Region { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        public bool WorkingInThisRole { get; set; } = false;

        [Required]
        public string StartDate { get; set; }

        //[Required]
        public string? EndDate { get; set; }

        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

    }
}
